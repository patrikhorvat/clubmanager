namespace CloudManager.Api.Models
{
    public class ManageEntityRequest<TEntity> : RequestBase
    {
        public TEntity? Dto { get; set; }
    }
}
