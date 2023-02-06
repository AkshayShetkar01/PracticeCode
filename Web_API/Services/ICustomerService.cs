using Domain.Models;


namespace Services
{
    public interface ICustomerService
    {
        int AddCustomer(string firstName, string lastName);
        List<Customer> GetCustomerList();
        int UpdateCustomer(string firstName, string customerCode);
        int DeleteCustomer(string customerCode);

    }
}
