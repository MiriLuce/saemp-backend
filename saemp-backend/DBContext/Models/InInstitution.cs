using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("inInstitution")]
    public partial class InInstitution
    {
        public InInstitution()
        {
            InCampuses = new HashSet<InCampus>();
        }

        [Key]
        [Column("idInstitution")]
        public int IdInstitution { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(15)]
        public string Abbreviation { get; set; }

        [InverseProperty(nameof(InCampus.IdInstitutionNavigation))]
        public virtual ICollection<InCampus> InCampuses { get; set; }
    }
}
