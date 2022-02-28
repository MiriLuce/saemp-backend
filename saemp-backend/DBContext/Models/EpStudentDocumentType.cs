using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("epStudentDocumentType")]
    public partial class EpStudentDocumentType
    {
        public EpStudentDocumentType()
        {
            SmStudentDocuments = new HashSet<SmStudentDocument>();
        }

        [Key]
        [Column("idStudentDocumentType")]
        public int IdStudentDocumentType { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(15)]
        public string Abbreviation { get; set; }
        [Column("effectiveDate", TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column("expirationDate", TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }
        [Column("inEffect")]
        public bool InEffect { get; set; }

        [InverseProperty(nameof(SmStudentDocument.IdStudentDocumentTypeNavigation))]
        public virtual ICollection<SmStudentDocument> SmStudentDocuments { get; set; }
    }
}
