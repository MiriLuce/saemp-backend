using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmBinnaclePayment
    {
        public long IdBinnaclePayment { get; set; }
        public long IdEnrollment { get; set; }
        public long IdEmployee { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Description { get; set; }

        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        public virtual EmEnrollment IdEnrollmentNavigation { get; set; }
    }
}
