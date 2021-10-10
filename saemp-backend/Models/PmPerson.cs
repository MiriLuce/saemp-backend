using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmPerson
    {
        public PmPerson()
        {
            PmPhones = new HashSet<PmPhone>();
            SmRelatives = new HashSet<SmRelative>();
            SmStudents = new HashSet<SmStudent>();
        }

        public long IdPerson { get; set; }
        public int IdTypeDocumentIdentity { get; set; }
        public string DocumentIdentity { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FatherlastName { get; set; }
        public string MotherlastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public int IdBirthCountry { get; set; }
        public int? IdResidentDepartment { get; set; }
        public int? IdResidentDistrict { get; set; }
        public string Address { get; set; }
        public string AddressReference { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual PmCountry IdBirthCountryNavigation { get; set; }
        public virtual PmDepartment IdResidentDepartmentNavigation { get; set; }
        public virtual PmDistrict IdResidentDistrictNavigation { get; set; }
        public virtual PmTypeDocumentIdentity IdTypeDocumentIdentityNavigation { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }
        public virtual ICollection<PmPhone> PmPhones { get; set; }
        public virtual ICollection<SmRelative> SmRelatives { get; set; }
        public virtual ICollection<SmStudent> SmStudents { get; set; }
    }
}
