namespace CloudManager.Api.Models
{
    public class ManageEntityResponse<TRequest> : ResponseBase<TRequest>
    {
        public int EntityId { get; set; }
        public long LongEntityId { get; set; }
        public Guid GuidEntityId { get; set; }
    }
}
