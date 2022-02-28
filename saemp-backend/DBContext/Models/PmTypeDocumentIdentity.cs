using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmTypeDocumentIdentity")]
    public partial class PmTypeDocumentIdentity
    {
        public PmTypeDocumentIdentity()
        {
            PmPeople = new HashSet<PmPerson>();
        }

        [Key]
        [Column("idTypeDocumentIdentity")]
        public int IdTypeDocumentIdentity { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(15)]
        public string Abbreviation { get; set; }
        [Column("length")]
        public short Length { get; set; }
        [Column("lengthType")]
        [StringLength(1)]
        public string LengthType { get; set; }
        [Column("characterType")]
        [StringLength(1)]
        public string CharacterType { get; set; }
        [Column("nationalityType")]
        [StringLength(1)]
        public string NationalityType { get; set; }
        [Required]
        [Column("isActive")]
        public bool? IsActive { get; set; }

        [InverseProperty(nameof(PmPerson.IdTypeDocumentIdentityNavigation))]
        public virtual ICollection<PmPerson> PmPeople { get; set; }
    }
}
