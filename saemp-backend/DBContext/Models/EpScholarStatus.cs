using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("epScholarStatus")]
    public partial class EpScholarStatus
    {
        public EpScholarStatus()
        {
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        [Key]
        [Column("idScholarStatus")]
        public short IdScholarStatus { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        [InverseProperty(nameof(SmStudentSchoolOrigin.IdScholarStatusNavigation))]
        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
