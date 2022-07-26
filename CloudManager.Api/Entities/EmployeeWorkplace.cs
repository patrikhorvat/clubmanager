using System;
using System.Collections.Generic;

namespace CloudManager.Api.Entities
{
    public partial class EmployeeWorkplace
    {
        public int Id { get; set; }
        public int Employee { get; set; }
        public int Workplace { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
        public bool? IsCurrent { get; set; }

        public virtual Employee EmployeeNavigation { get; set; } = null!;
        public virtual Workplace WorkplaceNavigation { get; set; } = null!;
    }
}
