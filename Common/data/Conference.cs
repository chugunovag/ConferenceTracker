using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Common.data
{
    /// <summary>
    /// Описание конференции: секция + информация 
    /// POKO объект для хранения в БД
    /// </summary>
    [DataContract(Name = "conference")]
    public class Conference
    {
        /// <summary>
        /// Необходимо для хранения в LiteDB
        /// </summary>
        [IgnoreDataMember]
        public int Id { get; set; }

        [DataMember(Name = "section")]
        public string Section { get; set; }

        [DataMember(Name = "info")]
        public ConferenceInfo Info  { get; set; }

        public override string ToString()
        {
            return $"[Section: {Section}: [{Info}]]";
        }

        protected bool Equals(Conference other)
        {
            return string.Equals(Section, other.Section) && Equals(Info, other.Info);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Conference) obj);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Section?.GetHashCode() ?? 0)*397) ^ (Info?.GetHashCode() ?? 0);
            }
        }

        public Conference Convert()
        {
            return this;
        }
    }
}
