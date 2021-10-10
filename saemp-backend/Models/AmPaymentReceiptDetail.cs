using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmPaymentReceiptDetail
    {
        public AmPaymentReceiptDetail()
        {
            AmPaymentTransactionDetails = new HashSet<AmPaymentTransactionDetail>();
        }

        public long IdPaymentReceiptDetail { get; set; }
        public long IdPaymentReceipt { get; set; }
        public long IdStudentInstallment { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }

        public virtual AmPaymentReceipt IdPaymentReceiptNavigation { get; set; }
        public virtual AmStudentInstallment IdStudentInstallmentNavigation { get; set; }
        public virtual ICollection<AmPaymentTransactionDetail> AmPaymentTransactionDetails { get; set; }
    }
}
