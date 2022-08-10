using System.Runtime.Serialization;

namespace CloudManager.Api.Models
{
    [DataContract]
    public class ResponseBase<TRequest> : IResponse
    {
        [DataMember]
        public TRequest? Request { get; set; }
        [DataMember]
        public Guid ResponseToken { get; set; }
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string? Message { get; set; }
        [DataMember]
        public int StatusCode { get; set; }
    }
}
