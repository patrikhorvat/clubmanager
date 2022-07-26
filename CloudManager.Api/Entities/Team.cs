using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class Team
    {
        public Team()
        {
            EmployeeTeams = new HashSet<EmployeeTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string League { get; set; } = null!;
        public bool Active { get; set; }
        public int Status { get; set; }
        public int Club { get; set; }

        public virtual Club ClubNavigation { get; set; } = null!;
        public virtual Status StatusNavigation { get; set; } = null!;
        public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; }
    }
}
