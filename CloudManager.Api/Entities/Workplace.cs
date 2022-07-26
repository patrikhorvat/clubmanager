using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class Workplace
    {
        public Workplace()
        {
            EmployeeWorkplaces = new HashSet<EmployeeWorkplace>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Label { get; set; } = null!;
        public decimal? Salary { get; set; }

        public virtual ICollection<EmployeeWorkplace> EmployeeWorkplaces { get; set; }
    }
}
