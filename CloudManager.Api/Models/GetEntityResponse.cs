namespace CloudManager.Api.Models
{
    public class GetEntityResponse<T> : ResponseBase<GetEntityRequest>
    {
        public T? Entity { get; set; }
    }
}
