namespace ClubManagerAPI.Models
{
    public class AssetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public AssetTypeModel AssetType { get; set; }
        public StatusModel Status { get; set; }
        public string? Condition { get; set; }
        public string? Description { get; set; }
        public ClubModel Club { get; set; }

        public UserModel UserCreated { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public UserModel? UserLastModified { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}
