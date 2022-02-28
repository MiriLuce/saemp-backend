using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amPaymentTransactionDetail")]
    public partial class AmPaymentTransactionDetail
    {
        [Column("idPaymentTransactionDetail")]
        public long IdPaymentTransactionDetail { get; set; }
        [Key]
        [Column("idPaymentTransaction")]
        public long IdPaymentTransaction { get; set; }
        [Column("idPaymentReceiptDetail")]
        public long IdPaymentReceiptDetail { get; set; }
        [Column("totalAmount", TypeName = "decimal(4, 2)")]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(IdPaymentReceiptDetail))]
        [InverseProperty(nameof(AmPaymentReceiptDetail.AmPaymentTransactionDetails))]
        public virtual AmPaymentReceiptDetail IdPaymentReceiptDetailNavigation { get; set; }
        [ForeignKey(nameof(IdPaymentTransaction))]
        [InverseProperty(nameof(AmPaymentTransaction.AmPaymentTransactionDetail))]
        public virtual AmPaymentTransaction IdPaymentTransactionNavigation { get; set; }
    }
}
