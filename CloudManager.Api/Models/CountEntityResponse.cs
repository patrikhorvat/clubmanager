namespace CloudManager.Api.Models
{
    public class CountEntityResponse : ResponseBase<CountEntityRequest>
    {
        public int Count { get; set; }
    }
}
