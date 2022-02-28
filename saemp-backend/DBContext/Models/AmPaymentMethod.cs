using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amPaymentMethod")]
    public partial class AmPaymentMethod
    {
        public AmPaymentMethod()
        {
            AmPaymentTransactions = new HashSet<AmPaymentTransaction>();
        }

        [Key]
        [Column("idPaymentMethod")]
        public short IdPaymentMethod { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        [InverseProperty(nameof(AmPaymentTransaction.IdPaymentMethodNavigation))]
        public virtual ICollection<AmPaymentTransaction> AmPaymentTransactions { get; set; }
    }
}
