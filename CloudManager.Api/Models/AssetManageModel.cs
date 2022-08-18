namespace CloudManager.Api.Models
{
    public class AssetManageModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? StatusId { get; set; }
        public string Description { get; set; } = null!;
        public string Condition { get; set; } = null!;
        public int? Type { get; set; }

    }
}
