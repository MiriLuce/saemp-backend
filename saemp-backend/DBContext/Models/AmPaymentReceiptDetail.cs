using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amPaymentReceiptDetail")]
    public partial class AmPaymentReceiptDetail
    {
        public AmPaymentReceiptDetail()
        {
            AmPaymentTransactionDetails = new HashSet<AmPaymentTransactionDetail>();
        }

        [Key]
        [Column("idPaymentReceiptDetail")]
        public long IdPaymentReceiptDetail { get; set; }
        [Column("idPaymentReceipt")]
        public long IdPaymentReceipt { get; set; }
        [Column("idStudentInstallment")]
        public long IdStudentInstallment { get; set; }
        [Column("totalAmount", TypeName = "decimal(4, 2)")]
        public decimal TotalAmount { get; set; }
        [Column("description")]
        [StringLength(250)]
        public string Description { get; set; }

        [ForeignKey(nameof(IdPaymentReceipt))]
        [InverseProperty(nameof(AmPaymentReceipt.AmPaymentReceiptDetails))]
        public virtual AmPaymentReceipt IdPaymentReceiptNavigation { get; set; }
        [ForeignKey(nameof(IdStudentInstallment))]
        [InverseProperty(nameof(AmStudentInstallment.AmPaymentReceiptDetails))]
        public virtual AmStudentInstallment IdStudentInstallmentNavigation { get; set; }
        [InverseProperty(nameof(AmPaymentTransactionDetail.IdPaymentReceiptDetailNavigation))]
        public virtual ICollection<AmPaymentTransactionDetail> AmPaymentTransactionDetails { get; set; }
    }
}
