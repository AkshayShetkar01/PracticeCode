using Domain.Models;
using Infrastructure.Repositories;
using System.Globalization;

namespace Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository)
        {
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
        }

        public void AddInvoice(string customerCode, string amount)
        {
            try
            {

                ValidateCustomerCode(customerCode);
                ValidateInvoice(amount);
                validateAmount(amount);

                _invoiceRepository.AddInvoice(new Invoice()
                {
                    InvoiceDate = DateTime.Now.ToString(),
                    CustomerCode = customerCode,
                    Amount = decimal.Parse(amount)
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ValidateInvoice(string amount)
        {
            if (!decimal.TryParse(amount, out decimal result1))
            {
                throw new FormatException("Invalid amount format");
            }
        }

        public void validateAmount(string amount)
        {
            decimal amt = decimal.Parse(amount);

            if (amt <= 0 || amt >= 20000)
            {
                throw new Exception("Invalid amount ");
            }
        }


        public void ConfirmPayment()
        {
            try
            {
                Console.WriteLine("Enter invoice No : ");

                string invoiceNo = Console.ReadLine();

                ValidateInvoiceNoFormat(invoiceNo);
                ValidateInvoiceNo(invoiceNo);

                Console.WriteLine("Enter Customer Code : ");

                string customerCode = Console.ReadLine();

                ValidateCustomerCode(customerCode);


                Console.WriteLine(_invoiceRepository.ConfirmPayment(invoiceNo, customerCode));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ValidateCustomerCode(string customerCode)
        {
            var list = _customerRepository.GetCustomerList();

            foreach (var customer in list)
            {
                if (customerCode == customer.CustomerCode)
                {

                    return;
                }
            }

            throw new FormatException("Invalid customer code ");

        }

        public void ValidateInvoiceNo(string invoiceNo)
        {
            

            var list = _invoiceRepository.GetInvoiceList();

            foreach (var customer in list)
            {
                if (int.Parse(invoiceNo) == customer.InvoiceNo)
                {
                    return;
                }
            }

            throw new FormatException("Invalid Invoice number ");
        }




        private void ValidateInvoiceNoFormat(string invoiceNo)
        {
            if (!int.TryParse(invoiceNo, out int i))
            {
                throw new FormatException("Invalid invoice No ");
            }

        }

        public List<DetailedInvoice> GetInvoiceList(string searchKey)
        {

            var invoiceList = _invoiceRepository.GetInvoiceList(searchKey.ToLower());

            if (invoiceList.Count != 0 )
            {
                Console.WriteLine($"Invoice Date    Invoice no    Full name         Amount    Status    \n");
                return invoiceList;
            }
            else
            {
                Console.WriteLine("Invalid search Text");
            }

            return null;

        }


    }
}
