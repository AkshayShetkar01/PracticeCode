using Domain.Models;
namespace Services
{
    public interface IInvoiceService
    {
        List<DetailedInvoice> GetInvoiceList(string searchKey);

        void AddInvoice (string customerCode, string amount);

        void ConfirmPayment();

    }
}
