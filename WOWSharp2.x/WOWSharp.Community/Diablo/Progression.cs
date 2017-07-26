using System.Runtime.Serialization;

namespace WOWSharp.Community.Diablo
{
	/// <summary>
	/// The progression of a character or a profile 
	/// </summary>
	[DataContract]
    public class Progression
    {
        /// <summary>
        /// Gets or sets act 1 progression
        /// </summary>
        [DataMember(Name = "act1", IsRequired = false)]
        public ActProgression Act1
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets act 2 progression
        /// </summary>
        [DataMember(Name = "act2", IsRequired = false)]
        public ActProgression Act2
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets act 3 progression
        /// </summary>
        [DataMember(Name = "act3", IsRequired = false)]
        public ActProgression Act3
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets act 4 progression
        /// </summary>
        [DataMember(Name = "act4", IsRequired = false)]
        public ActProgression Act4
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets act 5 progression
        /// </summary>
        /// <remarks>Act 5 will always be null until Reaper of Souls expansion</remarks>
        [DataMember(Name = "act5", IsRequired = false)]
        public ActProgression Act5
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets whether the act is completed
        /// </summary>
        /// <remarks>Since Reaper of souls is not out, we check for Act 4 completion</remarks>
        public bool IsCompleted
        {
            get
            {
                return Act4 != null && Act4.IsCompleted;
            }
        }

        /// <summary>
        /// Gets the last act completed
        /// </summary>
        public DiabloAct CompletedAct
        {
            get
            {
				if (Act5 != null && Act5.IsCompleted)
				{
					return DiabloAct.Act5;
				}

				if (Act4 != null && Act4.IsCompleted)
				{
					return DiabloAct.Act4;
				}

				if (Act3 != null && Act3.IsCompleted)
				{
					return DiabloAct.Act3;
				}

				if (Act2 != null && Act2.IsCompleted)
				{
					return DiabloAct.Act2;
				}

				if (Act1 != null && Act1.IsCompleted)
				{
					return DiabloAct.Act1;
				}

                return DiabloAct.None;
            }
        }

        /// <summary>
        /// String representation for debugging purposes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return CompletedAct.ToString();
        }
    }
}
