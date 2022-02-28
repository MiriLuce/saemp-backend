using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amPaymentReceipt")]
    public partial class AmPaymentReceipt
    {
        public AmPaymentReceipt()
        {
            AmPaymentReceiptDetails = new HashSet<AmPaymentReceiptDetail>();
        }

        [Key]
        [Column("idPaymentReceipt")]
        public long IdPaymentReceipt { get; set; }
        [Column("idEmployee")]
        public long IdEmployee { get; set; }
        [Column("idCampus")]
        public int IdCampus { get; set; }
        [Required]
        [Column("serieNumber")]
        [StringLength(5)]
        public string SerieNumber { get; set; }
        [Required]
        [Column("receiptNumber")]
        [StringLength(10)]
        public string ReceiptNumber { get; set; }
        [Column("totalAmount", TypeName = "decimal(4, 2)")]
        public decimal TotalAmount { get; set; }
        [Column("comment")]
        [StringLength(250)]
        public string Comment { get; set; }
        [Column("paymentDate", TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }
        [Column("registrationDate", TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }

        [ForeignKey(nameof(IdCampus))]
        [InverseProperty(nameof(InCampus.AmPaymentReceipts))]
        public virtual InCampus IdCampusNavigation { get; set; }
        [ForeignKey(nameof(IdEmployee))]
        [InverseProperty(nameof(HrEmployee.AmPaymentReceipts))]
        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        [InverseProperty(nameof(AmPaymentReceiptDetail.IdPaymentReceiptNavigation))]
        public virtual ICollection<AmPaymentReceiptDetail> AmPaymentReceiptDetails { get; set; }
    }
}
