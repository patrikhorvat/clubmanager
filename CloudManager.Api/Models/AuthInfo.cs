using System.Runtime.Serialization;

namespace CloudManager.Api.Models
{
        [DataContract]
        public class AuthInfo
        {
            [DataMember]
            public int UserId { get; set; }

        }
}
