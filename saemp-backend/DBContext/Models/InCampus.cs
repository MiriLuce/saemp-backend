using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("inCampus")]
    public partial class InCampus
    {
        public InCampus()
        {
            AmPaymentReceipts = new HashSet<AmPaymentReceipt>();
            InRooms = new HashSet<InRoom>();
        }

        [Key]
        [Column("idCampus")]
        public int IdCampus { get; set; }
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
        [Column("address")]
        [StringLength(200)]
        public string Address { get; set; }
        [Column("addressReference")]
        [StringLength(200)]
        public string AddressReference { get; set; }

        [ForeignKey(nameof(IdInstitution))]
        [InverseProperty(nameof(InInstitution.InCampuses))]
        public virtual InInstitution IdInstitutionNavigation { get; set; }
        [InverseProperty(nameof(AmPaymentReceipt.IdCampusNavigation))]
        public virtual ICollection<AmPaymentReceipt> AmPaymentReceipts { get; set; }
        [InverseProperty(nameof(InRoom.IdCampusNavigation))]
        public virtual ICollection<InRoom> InRooms { get; set; }
    }
}
