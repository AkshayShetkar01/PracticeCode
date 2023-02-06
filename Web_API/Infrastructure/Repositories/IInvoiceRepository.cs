using Domain.Models;

namespace Infrastructure.Repositories
{
    public interface IInvoiceRepository
    {
        List<DetailedInvoice> GetInvoiceList(string searchKey);

        string AddInvoice(Invoice invoice);

        string ConfirmPayment(string invoiceNo, string customerCode);

        List<Invoice> GetInvoiceList();
    }
} 
