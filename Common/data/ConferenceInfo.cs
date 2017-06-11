using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Common.data {
    /// <summary>
    ///     Информация о конференции: место, название  ит.п.
    /// </summary>
    [DataContract]
    public class ConferenceInfo {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        public override string ToString() {
            return $"[Info: {Name}, {City}, {Location}]";
        }

        protected bool Equals(ConferenceInfo other) {
            return string.Equals(Name, other.Name) && string.Equals(City, other.City) &&
                   string.Equals(Location, other.Location);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ConferenceInfo) obj);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode() {
            unchecked {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (City?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Location?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}