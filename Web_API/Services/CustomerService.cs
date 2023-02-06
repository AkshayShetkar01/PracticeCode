using Domain.Models;
using Infrastructure.Repositories;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository; 

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int AddCustomer( string firstName , string lastName )
        {

            string customerCode = GenerateCustomerCode(firstName, lastName);

            int result = _customerRepository.AddCustomer(new Customer {
                FirstName = firstName,
                LastName = lastName,
                CustomerCode = customerCode
            });

            return result;
        }

        public static string GenerateCustomerCode(string firstName, string lastName)
        {
            Random random = new Random();
 
            string customerCode = (firstName.Substring(0,1).ToUpper()) + (lastName.Substring(0,1).ToUpper()) + random.Next(100, 900);

            return customerCode;
        }

        public List<Customer> GetCustomerList()
        {
            var customerList = _customerRepository.GetCustomerList();
            return customerList;
        }

        public int UpdateCustomer(string firstName, string customerCode)
        {
            try
            {
                var isCustomerUpdated = _customerRepository.UpdateCustomer(firstName, customerCode);

                return isCustomerUpdated;
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw ex;
            }


        }

        public int DeleteCustomer(string customerCode)
        {
            try
            {
                var isCustomerDeleted = _customerRepository.DeleteCustomer(customerCode);

                return isCustomerDeleted;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            
        }
    }
}
