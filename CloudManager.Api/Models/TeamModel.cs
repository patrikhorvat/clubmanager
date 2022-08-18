namespace CloudManager.Api.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public string? StatusColor { get; set; }
        public int? Club { get; set; }
        public string? League { get; set; }
    }
}
