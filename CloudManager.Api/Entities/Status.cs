using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class Status
    {
        public Status()
        {
            Assets = new HashSet<Asset>();
            Employees = new HashSet<Employee>();
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Label { get; set; } = null!;
        public int GroupId { get; set; }
        public string Color { get; set; } = null!;
        public int RegistryTypeId { get; set; }

        public virtual StatusGroup Group { get; set; } = null!;
        public virtual RegistryType RegistryType { get; set; } = null!;
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
