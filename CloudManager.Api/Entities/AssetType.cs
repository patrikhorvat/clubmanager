using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class AssetType
    {
        public AssetType()
        {
            Assets = new HashSet<Asset>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Label { get; set; } = null!;

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
