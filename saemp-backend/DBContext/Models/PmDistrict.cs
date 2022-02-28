using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmDistrict")]
    [Index(nameof(Ubigeo), Name = "UQ__pmDistri__3126FF0016415AE5", IsUnique = true)]
    public partial class PmDistrict
    {
        public PmDistrict()
        {
            PmPeople = new HashSet<PmPerson>();
        }

        [Key]
        [Column("idDistrict")]
        public int IdDistrict { get; set; }
        [Column("idDepartment")]
        public int IdDepartment { get; set; }
        [Column("idProvince")]
        public int IdProvince { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("ubigeo")]
        [StringLength(6)]
        public string Ubigeo { get; set; }
        [Column("isDefault")]
        public bool IsDefault { get; set; }

        [ForeignKey(nameof(IdDepartment))]
        [InverseProperty(nameof(PmDepartment.PmDistricts))]
        public virtual PmDepartment IdDepartmentNavigation { get; set; }
        [ForeignKey(nameof(IdProvince))]
        [InverseProperty(nameof(PmProvince.PmDistricts))]
        public virtual PmProvince IdProvinceNavigation { get; set; }
        [InverseProperty(nameof(PmPerson.IdResidentDistrictNavigation))]
        public virtual ICollection<PmPerson> PmPeople { get; set; }
    }
}
