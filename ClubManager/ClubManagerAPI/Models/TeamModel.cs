namespace ClubManagerAPI.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? League { get; set; }
        public StatusModel Status { get; set; }
        public ClubModel Club { get; set; }
    }
}
