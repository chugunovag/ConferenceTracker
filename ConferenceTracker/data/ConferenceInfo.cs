using System.Runtime.Serialization;

namespace ConferenceTracker.data
{
    [DataContract]
    public class ConferenceInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "location")]
        public string Location { get; set; }

        public override string ToString()
        {
            return $"[Info: {Name}, {City}, {Location}]";
        }
    }
}
