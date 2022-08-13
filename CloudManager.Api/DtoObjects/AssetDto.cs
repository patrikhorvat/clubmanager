namespace CloudManager.Api.DtoObjects
{
    public class AssetDto
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int? UserCreatedId { get; set; }
        public string? UserCreatedDisplayName { get; set; }
        public string Name { get; set; } = null!;
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public string? StatusColor { get; set; }
        public int? Club { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public int? UserLastModifiedId { get; set; }
        public string? UserLastModifiedDisplayName { get; set; }
        public string Description { get; set; } = null!;
        public string Condition { get; set; } = null!;
        public int? Type { get; set; }
        public string AssetTypeName { get; set; } = null!;
        public string AssetTypeLabel { get; set; } = null!;
    }
}
