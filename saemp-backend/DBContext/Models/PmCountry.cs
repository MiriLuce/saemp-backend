using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmCountry")]
    public partial class PmCountry
    {
        public PmCountry()
        {
            PmPeople = new HashSet<PmPerson>();
        }

        [Key]
        [Column("idCountry")]
        public int IdCountry { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("letterCode")]
        [StringLength(3)]
        public string LetterCode { get; set; }
        [Required]
        [Column("numericCode")]
        [StringLength(3)]
        public string NumericCode { get; set; }
        [Column("isDefault")]
        public bool IsDefault { get; set; }

        [InverseProperty(nameof(PmPerson.IdBirthCountryNavigation))]
        public virtual ICollection<PmPerson> PmPeople { get; set; }
    }
}
