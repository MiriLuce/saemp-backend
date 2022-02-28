using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("pmPhone")]
    public partial class PmPhone
    {
        [Key]
        [Column("idPhone")]
        public long IdPhone { get; set; }
        [Column("idPerson")]
        public long IdPerson { get; set; }
        [Column("idPhoneCompany")]
        public short? IdPhoneCompany { get; set; }
        [Column("idPhoneType")]
        public short? IdPhoneType { get; set; }
        [Required]
        [Column("number")]
        [StringLength(25)]
        public string Number { get; set; }
        [Column("isForEmergency")]
        public bool IsForEmergency { get; set; }
        [Column("description")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(IdPerson))]
        [InverseProperty(nameof(PmPerson.PmPhones))]
        public virtual PmPerson IdPersonNavigation { get; set; }
        [ForeignKey(nameof(IdPhoneCompany))]
        [InverseProperty(nameof(PmPhoneCompany.PmPhones))]
        public virtual PmPhoneCompany IdPhoneCompanyNavigation { get; set; }
        [ForeignKey(nameof(IdPhoneType))]
        [InverseProperty(nameof(PmPhoneType.PmPhones))]
        public virtual PmPhoneType IdPhoneTypeNavigation { get; set; }
    }
}
