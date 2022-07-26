using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class RegistryType
    {
        public RegistryType()
        {
            Statuses = new HashSet<Status>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Label { get; set; } = null!;

        public virtual ICollection<Status> Statuses { get; set; }
    }
}
