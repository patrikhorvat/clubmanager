namespace CloudManager.Api.Models
{
    public class OverviewResponse<T> : ResponseBase<OverviewRequest>
    {
        public IEnumerable<T>? Data { get; set; }
        public int Total { get; set; }
    }
}
