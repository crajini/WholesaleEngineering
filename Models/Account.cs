using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Account: BaseAccount
    {
        [DataMember]
        public int UserId { get; set; }
        
        [DataMember]
        public DateTime BalanceDate { get; set; }

        [DataMember]
        public string OpeningAvailableBalance { get; set; }

        [DataMember]
        public string AccountType { get; set; }
    }
}
