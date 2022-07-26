using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTeams = new HashSet<EmployeeTeam>();
            EmployeeWorkplaces = new HashSet<EmployeeWorkplace>();
        }

        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int? UserCreated { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Status { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public DateTimeOffset? DateEmployeed { get; set; }
        public DateTimeOffset? EmployedTo { get; set; }
        public string? Oib { get; set; }
        public int? Club { get; set; }
        public string? IdentityUserId { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public int? UserLastModified { get; set; }

        public virtual Club? ClubNavigation { get; set; }
        public virtual AspNetUser? IdentityUser { get; set; }
        public virtual Status StatusNavigation { get; set; } = null!;
        public virtual User? UserCreatedNavigation { get; set; }
        public virtual User? UserLastModifiedNavigation { get; set; }
        public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; }
        public virtual ICollection<EmployeeWorkplace> EmployeeWorkplaces { get; set; }
    }
}
