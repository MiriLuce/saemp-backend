using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EmSchoolYearLevel
    {
        public EmSchoolYearLevel()
        {
            AmSchoolYearPayments = new HashSet<AmSchoolYearPayment>();
        }

        public long IdSchoolYearLevel { get; set; }
        public long IdSchoolYear { get; set; }
        public short IdSchoolLevel { get; set; }
        public int VacancyAmount { get; set; }
        public int TotalStudentEnrolledAmount { get; set; }
        public int NewStudentEnrolledAmount { get; set; }

        public virtual EpSchoolLevel IdSchoolLevelNavigation { get; set; }
        public virtual EmSchoolYear IdSchoolYearNavigation { get; set; }
        public virtual ICollection<AmSchoolYearPayment> AmSchoolYearPayments { get; set; }
    }
}
