namespace Domain.Models
{
    public class DetailedInvoice
    {
        public string InvoiceDate { get; set; }
        public int InvoiceNo { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

    }
}
