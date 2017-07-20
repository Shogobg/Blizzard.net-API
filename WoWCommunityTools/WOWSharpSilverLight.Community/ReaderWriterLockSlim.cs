using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WOWSharp.Community
{
    /// <summary>
    /// Dummy class because Silverlight doesn't have ReaderWriterLockSlim
    /// </summary>
    internal class ReaderWriterLockSlim : IDisposable
    {
        /// <summary>
        /// does nothing
        /// </summary>
        public void EnterReadLock()
        {

        }

        /// <summary>
        /// does nothing
        /// </summary>
        public void EnterWriteLock()
        {
        }

        /// <summary>
        /// does nothing
        /// </summary>
        public void ExitWriteLock()
        {
        }

        /// <summary>
        /// does nothing
        /// </summary>
        public void ExitReadLock()
        {
        }

        #region IDisposable Members

        /// <summary>
        /// Do nothing
        /// </summary>
        public void Dispose()
        {
            
        }

        #endregion
    }
}
