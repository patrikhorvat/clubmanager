namespace CloudManager.Api.Models
{
    public class DeleteEntityRequest : RequestBase
    {
        public int EntityId { get; set; }
        public Guid GuidEntityId { get; set; }
    }
}
