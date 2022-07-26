using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class Asset
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int UserCreated { get; set; }
        public string Name { get; set; } = null!;
        public int Type { get; set; }
        public int Status { get; set; }
        public string? Condition { get; set; }
        public string? Description { get; set; }
        public int? Club { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public int? UserLastModified { get; set; }

        public virtual Status StatusNavigation { get; set; } = null!;
        public virtual AssetType TypeNavigation { get; set; } = null!;
        public virtual User UserCreatedNavigation { get; set; } = null!;
        public virtual User? UserLastModifiedNavigation { get; set; }
    }
}
