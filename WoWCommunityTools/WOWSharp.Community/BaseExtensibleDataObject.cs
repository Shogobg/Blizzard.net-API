using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WOWSharp.Community
{
    /// <summary>
    /// Base class for all data contract classes. 
    /// Used to provide storage for fields that are added to the api by Blizzard later.
    /// Allows the additional data to be serialized back even if the member is not supported by the current version of the API.
    /// </summary>
    [DataContract]
    [Serializable]
    public class BaseExtensibleDataObject : IExtensibleDataObject
    {
        /// <summary>
        /// Extension data
        /// </summary>
        [NonSerialized]
        private ExtensionDataObject _extensionData;
        
        #region IExtensibleDataObject Members

        /// <summary>
        /// Stores data from another version of the WOW api
        /// </summary>
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return _extensionData;
            }
            set
            {
                _extensionData = value;
            }
        }

        #endregion
    }
}
