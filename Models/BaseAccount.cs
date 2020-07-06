using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class BaseAccount
    {
        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public string Currency { get; set; }
    }
}
