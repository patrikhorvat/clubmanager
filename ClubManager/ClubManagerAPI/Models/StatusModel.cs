namespace ClubManagerAPI.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Background { get; set; }
        public string Foreground { get; set; }
        public StatusGroupModel Group { get; set; }
    }
}
