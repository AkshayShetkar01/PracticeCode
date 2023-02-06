using Domain.Models;
using Microsoft.Data.SqlClient;


namespace Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {

        private const string connectionString = "Data Source =.; Initial Catalog = InvoiceDb; Integrated Security = True; TrustServerCertificate=True;";

        public List<DetailedInvoice> GetInvoiceList(string searchKey)
        {
            List<DetailedInvoice> invoices = new List<DetailedInvoice>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                string selectStatement = "spSearchText";

                SqlCommand command = new SqlCommand(selectStatement, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@searchText", searchKey);

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    DetailedInvoice invoice = new DetailedInvoice()
                    {
                        InvoiceDate = ((DateTime)reader["Invoice Date"]).ToShortDateString(),
                        InvoiceNo = (int)reader["Number"],
                        CustomerCode = reader["Customer Code"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Amount = (decimal)reader["Amount"],
                        Status = reader["status"].ToString()
                    };

                    invoices.Add(invoice);
                }

                return invoices;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return invoices;
        }

        public string AddInvoice(Invoice newInvoice)
        {

            string insertStatementSp = "spAddInvoice";

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(insertStatementSp, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invoiceDate", newInvoice.InvoiceDate);
            command.Parameters.AddWithValue("@customerCode", newInvoice.CustomerCode);
            command.Parameters.AddWithValue("@amount", newInvoice.Amount);

            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter.ParameterName = "@IsSuccessful";
            outPutParameter.SqlDbType = System.Data.SqlDbType.Bit;
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(outPutParameter);

            connection.Open();
            command.ExecuteNonQuery();

            string isSuccessful = outPutParameter.Value.ToString();
            string result =  "Is insert operation successfull = " + isSuccessful;

            connection.Close();

            return result;

        }

        public string ConfirmPayment(string invoiceNo, string customerCode)
        {
            string insertAndDeleteStatemant = "spConfirmPayment";
            string result;

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(insertAndDeleteStatemant, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invoiceNo", invoiceNo);
            command.Parameters.AddWithValue("@customerCode", customerCode);

            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter.ParameterName = "@IsSuccessful";
            outPutParameter.SqlDbType = System.Data.SqlDbType.Bit;
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(outPutParameter);

            connection.Open();
            command.ExecuteNonQuery();

            var isSuccessful = outPutParameter.Value.ToString() ;

            if (isSuccessful.Equals("True"))
            {
               result  = "Payment confirmed \n";
            }
            else
            {
                result = "Payment Failed \n";
            }

            connection.Close();

            return result;
        }

        public List<Invoice> GetInvoiceList()
        {
            List<Invoice> invoices = new List<Invoice>();


            SqlConnection conn = new SqlConnection(connectionString);

            string selectStatement = "select * from invoice";

            SqlCommand command = new SqlCommand(selectStatement, conn);
            command.CommandType = System.Data.CommandType.Text;


            conn.Open();

            using SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Invoice invoice = new Invoice()
                {
                    InvoiceDate = reader["InvoiceDate"].ToString(),
                    InvoiceNo = (int) reader["InvoiceNo"],
                    CustomerCode = reader["CustomerCode"].ToString(),
                    Amount = (decimal)reader["Amount"]
                };

                invoices.Add(invoice);
            }

            return invoices;
        }
    }
}
