using System.Globalization;
using System.Runtime.Serialization;

namespace WOWSharp.Community.Wow
{
	/// <summary>
	///   Pets stats
	/// </summary>
	[DataContract]
    public class PetStats
    {
        /// <summary>
        ///   gets or sets breed id
        /// </summary>
        [DataMember(Name = "breedId", IsRequired = false)]
        public int BreedId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets health points
        /// </summary>
        [DataMember(Name = "health", IsRequired = false)]
        public int Health
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets level
        /// </summary>
        [DataMember(Name = "level", IsRequired = false)]
        public int Level
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet's quality
        /// </summary>
        [DataMember(Name = "petQualityId", IsRequired = false)]
        public ItemQuality Quality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets power
        /// </summary>
        [DataMember(Name = "power", IsRequired = false)]
        public int Power
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets species id
        /// </summary>
        [DataMember(Name = "speciesId", IsRequired = false)]
        public int SpeciesId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets pet's speed
        /// </summary>
        [DataMember(Name = "speed", IsRequired = false)]
        public int Speed
        {
            get;
            internal set;
        }

        /// <summary>
        ///   String representation for debugging purposes
        /// </summary>
        /// <returns> String representation for debugging purposes </returns>
        public override string ToString()
        {
            return "Level " + Level.ToString(CultureInfo.InvariantCulture);
        }
    }
}