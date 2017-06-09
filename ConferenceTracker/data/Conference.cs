using System.Runtime.Serialization;

namespace ConferenceTracker.data
{
    [DataContract]
    public class Conference
    {
        [DataMember(Name = "section")]
        public string Section { get; set; }
        [DataMember(Name = "info")]
        public ConferenceInfo Info  { get; set; }

        public override string ToString()
        {
            return $"[Section: {Section}: [{Info}]]";
        }
    }
}
