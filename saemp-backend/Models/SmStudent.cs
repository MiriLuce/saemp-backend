using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class SmStudent
    {
        public SmStudent()
        {
            EmEnrollments = new HashSet<EmEnrollment>();
            SmRelatives = new HashSet<SmRelative>();
            SmStudentDocuments = new HashSet<SmStudentDocument>();
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        public string IdStudent { get; set; }
        public long IdPerson { get; set; }
        public string Allergies { get; set; }
        public string Disease { get; set; }
        public string OtherHealthProblem { get; set; }
        public bool IsActive { get; set; }

        public virtual PmPerson IdPersonNavigation { get; set; }
        public virtual ICollection<EmEnrollment> EmEnrollments { get; set; }
        public virtual ICollection<SmRelative> SmRelatives { get; set; }
        public virtual ICollection<SmStudentDocument> SmStudentDocuments { get; set; }
        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
