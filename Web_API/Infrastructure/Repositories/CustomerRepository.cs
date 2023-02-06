using Domain.Models;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private const string connectionString = "Data Source =.; Initial Catalog = InvoiceDb; Integrated Security = True; TrustServerCertificate=True;";

        public int AddCustomer(Customer newCustomer)
        {
            string insertStatementSp = "spAddCustomer";

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                using SqlCommand command = new SqlCommand(insertStatementSp, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@customerCode", newCustomer.CustomerCode);
                command.Parameters.AddWithValue("@firstName", newCustomer.FirstName);
                command.Parameters.AddWithValue("@lastName", newCustomer.LastName);

                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@IsSuccessful";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Bit;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(outPutParameter);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
            
        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                string selectStatement = "select * from customer";

                SqlCommand command = new SqlCommand(selectStatement, conn);
                command.CommandType = System.Data.CommandType.Text;


                conn.Open();

                using SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Customer customer = new Customer()
                    {
                        CustomerCode = reader["CustomerCode"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };

                    customers.Add(customer);
                }

                conn.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return customers;
        }

        public int UpdateCustomer(string firstName, string customerCode)
        {
            string updateStatementSp = "UPDATE Customer " +
                "SET FirstName = @firstName " +
                "WHERE customerCode = @customerCode";

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                using SqlCommand command = new SqlCommand(updateStatementSp, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@customerCode", customerCode);
                

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                throw ex;
            }


        }

        public int DeleteCustomer(string customerCode)
        {
            string updateStatementSp = "DELETE FROM Customer " +
                "WHERE CustomerCode = @CustomerCode";

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                using SqlCommand command = new SqlCommand(updateStatementSp, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@customerCode", customerCode);
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

    }
}
