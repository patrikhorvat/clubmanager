namespace CloudManager.Api.Models
{
    public class QueryParams
    {
        public string? WhereClause { get; set; }
        public string? OrderByClause { get; set; }
        public int? Take { get; set; }
        public int? Skip { get; set; }
    }
}
