namespace CloudManager.Api.Models
{
    public class GetEntityRequest : RequestBase
    {
        public int EntityId { get; set; }
        public long LongEntityId { get; set; }
        public Guid GuidEntityId { get; set; }
        public string? StringEntityId { get; set; }
    }
}
