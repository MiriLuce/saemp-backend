using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmDepartment")]
    public partial class PmDepartment
    {
        public PmDepartment()
        {
            EpSchoolOrigins = new HashSet<EpSchoolOrigin>();
            PmDistricts = new HashSet<PmDistrict>();
            PmPeople = new HashSet<PmPerson>();
            PmProvinces = new HashSet<PmProvince>();
        }

        [Key]
        [Column("idDepartment")]
        public int IdDepartment { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("code")]
        [StringLength(2)]
        public string Code { get; set; }
        [Column("isDefault")]
        public bool IsDefault { get; set; }

        [InverseProperty(nameof(EpSchoolOrigin.IdDepartmentNavigation))]
        public virtual ICollection<EpSchoolOrigin> EpSchoolOrigins { get; set; }
        [InverseProperty(nameof(PmDistrict.IdDepartmentNavigation))]
        public virtual ICollection<PmDistrict> PmDistricts { get; set; }
        [InverseProperty(nameof(PmPerson.IdResidentDepartmentNavigation))]
        public virtual ICollection<PmPerson> PmPeople { get; set; }
        [InverseProperty(nameof(PmProvince.IdDepartmentNavigation))]
        public virtual ICollection<PmProvince> PmProvinces { get; set; }
    }
}
