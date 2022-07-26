using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class Club
    {
        public Club()
        {
            Employees = new HashSet<Employee>();
            Teams = new HashSet<Team>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTimeOffset? DateFound { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
