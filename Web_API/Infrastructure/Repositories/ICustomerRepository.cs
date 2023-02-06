using Domain.Models;

namespace Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        List<Customer> GetCustomerList();
        int UpdateCustomer(string firstName, string customerCode);
        int DeleteCustomer(string customerCode);


    }
}
