using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmPerson")]
    public partial class PmPerson
    {
        public PmPerson()
        {
            PmPhones = new HashSet<PmPhone>();
            SmRelatives = new HashSet<SmRelative>();
            SmStudents = new HashSet<SmStudent>();
        }

        [Key]
        [Column("idPerson")]
        public long IdPerson { get; set; }
        [Column("idTypeDocumentIdentity")]
        public int IdTypeDocumentIdentity { get; set; }
        [Required]
        [Column("documentIdentity")]
        [StringLength(20)]
        public string DocumentIdentity { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Column("middleName")]
        [StringLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [Column("fatherlastName")]
        [StringLength(150)]
        public string FatherlastName { get; set; }
        [Column("motherlastName")]
        [StringLength(150)]
        public string MotherlastName { get; set; }
        [Column("email")]
        [StringLength(150)]
        public string Email { get; set; }
        [Column("birthdate", TypeName = "date")]
        public DateTime? Birthdate { get; set; }
        [Column("idBirthCountry")]
        public int IdBirthCountry { get; set; }
        [Column("idResidentDepartment")]
        public int? IdResidentDepartment { get; set; }
        [Column("idResidentDistrict")]
        public int? IdResidentDistrict { get; set; }
        [Column("address")]
        [StringLength(200)]
        public string Address { get; set; }
        [Column("addressReference")]
        [StringLength(200)]
        public string AddressReference { get; set; }
        [Column("registrationDate", TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [ForeignKey(nameof(IdBirthCountry))]
        [InverseProperty(nameof(PmCountry.PmPeople))]
        public virtual PmCountry IdBirthCountryNavigation { get; set; }
        [ForeignKey(nameof(IdResidentDepartment))]
        [InverseProperty(nameof(PmDepartment.PmPeople))]
        public virtual PmDepartment IdResidentDepartmentNavigation { get; set; }
        [ForeignKey(nameof(IdResidentDistrict))]
        [InverseProperty(nameof(PmDistrict.PmPeople))]
        public virtual PmDistrict IdResidentDistrictNavigation { get; set; }
        [ForeignKey(nameof(IdTypeDocumentIdentity))]
        [InverseProperty(nameof(PmTypeDocumentIdentity.PmPeople))]
        public virtual PmTypeDocumentIdentity IdTypeDocumentIdentityNavigation { get; set; }
        [InverseProperty("IdEmployeeNavigation")]
        public virtual HrEmployee HrEmployee { get; set; }
        [InverseProperty(nameof(PmPhone.IdPersonNavigation))]
        public virtual ICollection<PmPhone> PmPhones { get; set; }
        [InverseProperty(nameof(SmRelative.IdRelativeNavigation))]
        public virtual ICollection<SmRelative> SmRelatives { get; set; }
        [InverseProperty(nameof(SmStudent.IdPersonNavigation))]
        public virtual ICollection<SmStudent> SmStudents { get; set; }
    }
}
