// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace WOWSharp.Community
{
    /// <summary>
    ///   The Async result object for the ApiClient Async Requests
    /// </summary>
    internal class ApiAsyncResult<T> : IAsyncResult where T : class
    {
        // Constants
        /// <summary>
        ///   In Progress status
        /// </summary>
        private const int StateInProgress = 0;

        /// <summary>
        ///   Complete synchronously status
        /// </summary>
        private const int StateCompletedSychronously = 1;

        /// <summary>
        ///   Completed asynchronously status
        /// </summary>
        private const int StateCompletedAsynchronously = 2;

        /// <summary>
        ///   In valid state (used for CAS operation to read _state)
        /// </summary>
        private const int StateInvalid = -1;

        // readonly fields

        /// <summary>
        ///   Api Client used start the request
        /// </summary>
        private readonly ApiClient _apiClient;

        /// <summary>
        ///   Callback method
        /// </summary>
        private readonly AsyncCallback _asyncCallback;

        /// <summary>
        ///   User defined state
        /// </summary>
        private readonly object _asyncState;

        /// <summary>
        ///   Flag to make sure end is not called more than one time
        /// </summary>
        private int _endCalled;

        // fields

        /// <summary>
        ///   Wait handle for used to wait for the request
        /// </summary>
        private ManualResetEvent _event;

        /// <summary>
        ///   Exception thrown by the async operation
        /// </summary>
        private Exception _exception;

        /// <summary>
        ///   internal wait object 
        ///   (since _event can be returned to caller and disposed, we use this to wait for the operation to end)
        /// </summary>
        private ManualResetEvent _internalEvent;

        /// <summary>
        ///   result of the async operation
        /// </summary>
        private T _result;

        /// <summary>
        ///   current state of the async operation
        /// </summary>
        private int _status;

        /// <summary>
        ///   Constructor. initializes a new instance of ApiAsyncResult object
        /// </summary>
        /// <param name="callback"> Callback to call when operation is completed </param>
        /// <param name="asyncState"> User defined state </param>
        /// <param name="client"> ApiClient object used to start operation </param>
        public ApiAsyncResult(AsyncCallback callback, object asyncState, ApiClient client)
        {
            _status = StateInProgress;
            _asyncCallback = callback;
            _asyncState = asyncState;
            _apiClient = client;
        }

        #region IAsyncResult Members

        /// <summary>
        ///   gets the user defined state for the asyncresult
        /// </summary>
        public object AsyncState
        {
            get
            {
                return _asyncState;
            }
        }

        /// <summary>
        ///   Gets a wait handle used to wait on the request
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (_event == null)
                {
                    bool done = IsCompleted;
                    var evt = new ManualResetEvent(done);
                    if (Interlocked.CompareExchange(ref _event, evt, null) != null)
                    {
                        // another thread created the event
                        // dispose ths one
                        evt.Dispose();
                    }
                    else
                    {
                        if (!done && IsCompleted)
                            _event.Set();
                    }
                }
                return _event;
            }
        }

        /// <summary>
        ///   Gets whether the operation is completed synchronously
        /// </summary>
        public bool CompletedSynchronously
        {
            get
            {
                return Interlocked.CompareExchange(ref _status, StateInvalid, StateInvalid) ==
                       StateCompletedSychronously;
            }
        }

        /// <summary>
        ///   Gets whether the operation is completed
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                return Interlocked.CompareExchange(ref _status, StateInvalid, StateInvalid) != StateInProgress;
            }
        }

        #endregion

        /// <summary>
        ///   Ends the processing of the operation and returns the result
        /// </summary>
        /// <param name="client"> Api client </param>
        /// <returns> the result of the async operation </returns>
        public T EndProcessing(ApiClient client)
        {
            if (client != _apiClient)
                throw new ArgumentException(ErrorMessages.InvalidAsyncResult, "client");
            if (Interlocked.CompareExchange(ref _endCalled, 1, 0) == 1)
                throw new InvalidOperationException(ErrorMessages.EndCalledAlready);
            if (!IsCompleted)
            {
                using (_internalEvent = new ManualResetEvent(IsCompleted))
                {
                    _internalEvent.WaitOne();
                }
            }
            if (_exception != null)
            {
                var apiException = _exception as ApiException;
                if (apiException != null)
                {
                    throw new ApiException(apiException.ApiError, apiException.HttpStatus, _exception);
                }
                throw new ApiException(_exception.Message, _exception);
            }
            return _result;
        }

        /// <summary>
        ///   Set operation as completed with exception
        /// </summary>
        /// <param name="exception"> Exception </param>
        /// <param name="completedSynchronously"> whether operation is completed asynchronously </param>
        internal void SetComplete(Exception exception, bool completedSynchronously)
        {
            SetCompletedInternal(null, exception,
                                 completedSynchronously ? StateCompletedSychronously : StateCompletedAsynchronously);
        }

        /// <summary>
        ///   Set operation as completed with result
        /// </summary>
        /// <param name="result"> result </param>
        /// <param name="completedSynchronously"> whether operation is completed asynchronously </param>
        internal void SetComplete(T result, bool completedSynchronously)
        {
            SetCompletedInternal(result, null,
                                 completedSynchronously ? StateCompletedSychronously : StateCompletedAsynchronously);
        }

        /// <summary>
        ///   Set operation as completed
        /// </summary>
        /// <param name="result"> result </param>
        /// <param name="exception"> exception </param>
        /// <param name="newStatus"> the completion status </param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void SetCompletedInternal(T result, Exception exception, int newStatus)
        {
            int prevStatus = Interlocked.CompareExchange(ref _status, newStatus, StateInProgress);
            // check if SetCompleted was called before
            if (prevStatus == StateInProgress)
            {
                _result = result;
                _exception = exception;
                // call the callback method
                if (_asyncCallback != null)
                {
                    try
                    {
                        _asyncCallback(this);
                    }
                    catch (Exception ex)
                    {
                        if (_exception == null)
                            _exception = ex;
                    }
                }
                // notify extenal callers
                if (_event != null)
                {
                    try
                    {
                        _event.Set();
                    }
                    catch (ObjectDisposedException)
                    {
                        // another caller can dispose the waithandle
                        // so ignore the exception
                    }
                }
                // Notify us
                if (_internalEvent != null)
                    _internalEvent.Set();
            }
        }
    }
}