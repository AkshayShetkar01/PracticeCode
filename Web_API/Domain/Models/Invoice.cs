namespace Domain.Models
{
    public class Invoice
    {
        public string InvoiceDate { get; set; }
        public int InvoiceNo { get; set; }
        public string CustomerCode { get; set; }
        public decimal Amount { get; set; }

    }
}
