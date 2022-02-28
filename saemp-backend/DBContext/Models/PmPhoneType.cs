using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmPhoneType")]
    public partial class PmPhoneType
    {
        public PmPhoneType()
        {
            PmPhones = new HashSet<PmPhone>();
        }

        [Key]
        [Column("idPhoneType")]
        public short IdPhoneType { get; set; }
        [Required]
        [Column("name")]
        [StringLength(25)]
        public string Name { get; set; }

        [InverseProperty(nameof(PmPhone.IdPhoneTypeNavigation))]
        public virtual ICollection<PmPhone> PmPhones { get; set; }
    }
}
