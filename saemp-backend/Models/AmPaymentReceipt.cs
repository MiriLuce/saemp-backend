using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmPaymentReceipt
    {
        public AmPaymentReceipt()
        {
            AmPaymentReceiptDetails = new HashSet<AmPaymentReceiptDetail>();
        }

        public long IdPaymentReceipt { get; set; }
        public long IdEmployee { get; set; }
        public int IdCampus { get; set; }
        public string SerieNumber { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Comment { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual InCampus IdCampusNavigation { get; set; }
        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        public virtual ICollection<AmPaymentReceiptDetail> AmPaymentReceiptDetails { get; set; }
    }
}
