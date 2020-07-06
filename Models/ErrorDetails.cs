using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class ErrorDetails
    {
        [DataMember]
        public int StatusCode { get; set; }
        [DataMember]
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
