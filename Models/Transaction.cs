using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Transaction: BaseAccount
    {   
        [DataMember]
        public DateTime ValueDate { get; set; }

        [DataMember]
        public string DebitAmount { get; set; }

        [DataMember]
        public string CreditAmount { get; set; }

        [DataMember]
        public string TransactionType { get; set; }

        [DataMember]
        public string Narrative { get; set; }

    }
}
