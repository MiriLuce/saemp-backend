using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmPhoneCompany")]
    public partial class PmPhoneCompany
    {
        public PmPhoneCompany()
        {
            PmPhones = new HashSet<PmPhone>();
        }

        [Key]
        [Column("idPhoneCompany")]
        public short IdPhoneCompany { get; set; }
        [Required]
        [Column("name")]
        [StringLength(25)]
        public string Name { get; set; }

        [InverseProperty(nameof(PmPhone.IdPhoneCompanyNavigation))]
        public virtual ICollection<PmPhone> PmPhones { get; set; }
    }
}
