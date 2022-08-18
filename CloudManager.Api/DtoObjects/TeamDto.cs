namespace CloudManager.Api.DtoObjects
{
    public class TeamDto
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
