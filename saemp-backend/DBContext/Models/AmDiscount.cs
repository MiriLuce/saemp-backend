using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amDiscount")]
    public partial class AmDiscount
    {
        public AmDiscount()
        {
            AmDiscountVersions = new HashSet<AmDiscountVersion>();
        }

        [Key]
        [Column("idDiscount")]
        public int IdDiscount { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(250)]
        public string Description { get; set; }
        [Column("needValidation")]
        public bool NeedValidation { get; set; }
        [Column("registrationDate", TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }

        [InverseProperty(nameof(AmDiscountVersion.IdDiscountNavigation))]
        public virtual ICollection<AmDiscountVersion> AmDiscountVersions { get; set; }
    }
}
