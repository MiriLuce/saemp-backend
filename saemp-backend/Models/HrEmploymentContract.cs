using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class HrEmploymentContract
    {
        public long IdEmploymentContract { get; set; }
        public long IdEmployee { get; set; }
        public int IdJobTitle { get; set; }
        public decimal? Salary { get; set; }
        public bool IsPerHour { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime CessationDate { get; set; }

        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        public virtual HrJobTitle IdJobTitleNavigation { get; set; }
    }
}
