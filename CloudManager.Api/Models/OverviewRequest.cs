namespace CloudManager.Api.Models
{
    public class OverviewRequest : RequestBase
    {
        public QueryParams? QueryParams { get; set; }

        public int EntityId { get; set; }
        public int RegistyTypeId { get; set; }
    }
}
