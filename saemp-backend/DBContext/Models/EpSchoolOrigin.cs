using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("epSchoolOrigin")]
    public partial class EpSchoolOrigin
    {
        public EpSchoolOrigin()
        {
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        [Key]
        [Column("idSchoolOrigin")]
        public long IdSchoolOrigin { get; set; }
        [Column("idDepartment")]
        public int IdDepartment { get; set; }
        [Column("idDistrict")]
        public int? IdDistrict { get; set; }
        [Column("name")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column("isPrivate")]
        public bool IsPrivate { get; set; }

        [ForeignKey(nameof(IdDepartment))]
        [InverseProperty(nameof(PmDepartment.EpSchoolOrigins))]
        public virtual PmDepartment IdDepartmentNavigation { get; set; }
        [InverseProperty(nameof(SmStudentSchoolOrigin.IdSchoolOriginNavigation))]
        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
