using System.Runtime.Serialization;

namespace CloudManager.Api.Models
{
    [DataContract]
    public class RequestBase : IRequest
    {
        [DataMember]
        public Guid RequestToken { get; set; }
        [DataMember]
        public AuthInfo? AuthInfo { get; set; }

    }
}
