using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class VAsset
    {
        public bool Active { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Type { get; set; }
        public int Status { get; set; }
        public string? Condition { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int UserCreated { get; set; }
        public int? UserLastModified { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string? AssetTypeName { get; set; }
        public string? AssetTypeLabel { get; set; }
        public string? StatusName { get; set; }
        public string? StatusLabel { get; set; }
        public string? StatusColor { get; set; }
        public int? StatusGroupId { get; set; }
        public string? StatusGroupName { get; set; }
        public string? StatusGroupLabel { get; set; }
    }
}
