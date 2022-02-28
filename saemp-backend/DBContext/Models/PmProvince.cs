using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmProvince")]
    public partial class PmProvince
    {
        public PmProvince()
        {
            PmDistricts = new HashSet<PmDistrict>();
        }

        [Key]
        [Column("idProvince")]
        public int IdProvince { get; set; }
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

        [ForeignKey(nameof(IdDepartment))]
        [InverseProperty(nameof(PmDepartment.PmProvinces))]
        public virtual PmDepartment IdDepartmentNavigation { get; set; }
        [InverseProperty(nameof(PmDistrict.IdProvinceNavigation))]
        public virtual ICollection<PmDistrict> PmDistricts { get; set; }
    }
}
