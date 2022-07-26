using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class User
    {
        public User()
        {
            AssetUserCreatedNavigations = new HashSet<Asset>();
            AssetUserLastModifiedNavigations = new HashSet<Asset>();
            EmployeeUserCreatedNavigations = new HashSet<Employee>();
            EmployeeUserLastModifiedNavigations = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdentityUserId { get; set; } = null!;
        public int? ClubId { get; set; }

        public virtual Club? Club { get; set; }
        public virtual AspNetUser IdentityUser { get; set; } = null!;
        public virtual ICollection<Asset> AssetUserCreatedNavigations { get; set; }
        public virtual ICollection<Asset> AssetUserLastModifiedNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeUserCreatedNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeUserLastModifiedNavigations { get; set; }
    }
}
