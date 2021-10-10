using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmPaymentTransactionDetail
    {
        public long IdPaymentTransactionDetail { get; set; }
        public long IdPaymentTransaction { get; set; }
        public long IdPaymentReceiptDetail { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual AmPaymentReceiptDetail IdPaymentReceiptDetailNavigation { get; set; }
        public virtual AmPaymentTransaction IdPaymentTransactionNavigation { get; set; }
    }
}
