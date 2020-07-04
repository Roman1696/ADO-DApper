using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Utils.Models;

namespace DataAccess
{
    public class CustomerRepositoryADO : ICustomerRepository
    {
        private readonly string connection = string.Empty;
        public CustomerRepositoryADO()
        {
            connection = ConfigurationManager.ConnectionStrings["HRSQLService"].ConnectionString;
        }



        int ICustomerRepository.DeleteCustomers(int id)
        {
            using (SqlConnection scn = new SqlConnection())
            {
                scn.ConnectionString = connection;
                scn.Open();

                var deleteOrder = "DELETE FROM CUSTOMERS WHERE Customer_id=@Customer_id;";

                SqlCommand sqlCommand = new SqlCommand(deleteOrder, scn);
                sqlCommand.Parameters.Add("@Customer_id", SqlDbType.Int).Value = id;
                var newCustomer = sqlCommand.ExecuteNonQuery();
                return newCustomer;
            }
        }

        IList<Customers> ICustomerRepository.GetAllCustomers()
        {
            var customersList = new List<Customers>();
            var selection = "Select Customer_name,Country,City,Region,Postal_code from Customers";
            var adapter = new SqlDataAdapter(selection, connection);
            var customersSet = new DataSet();

            adapter.Fill(customersSet, "Customer");

            foreach (DataRow row in customersSet.Tables["Customer"].Rows)
            {
                customersList.Add(new Customers(
                    (int)row[0],
                    (string)row[1],
                    (string)row[2],
                    (string)row[3],
                    (string)row[4],
                    (string)row[5]
                    ));
            }
            return customersList;
        }

        int ICustomerRepository.InsertCustomers(Customers customers)
        {
            using (SqlConnection scn = new SqlConnection())
            {
                scn.ConnectionString = connection;
                scn.Open();

                var insertCustomer = "Insert into Customers(Customer_id,Customer_name,Country,City,Region,Postal_code)" +
                    "values (@Customer_id,@Customer_name,@Country,@City,@Region,@Postal_code)";

                SqlCommand sqlCommand = new SqlCommand(insertCustomer, scn);
                sqlCommand.Parameters.Add("@Customer_id", SqlDbType.Int).Value = customers.Customer_id;
                sqlCommand.Parameters.Add("@Customer_name", SqlDbType.Int).Value = customers.Customer_name;
                sqlCommand.Parameters.Add("@Country", SqlDbType.Int).Value = customers.Country;
                sqlCommand.Parameters.Add("@City", SqlDbType.Int).Value = customers.City;
                sqlCommand.Parameters.Add("@Region", SqlDbType.Int).Value = customers.Region;
                sqlCommand.Parameters.Add("@Postal_code", SqlDbType.Int).Value = customers.Postal_code;
                var newCustomer = sqlCommand.ExecuteNonQuery();
                return newCustomer;
            }

        }

        int ICustomerRepository.UpdateCustomers(int id)
        {
            using (SqlConnection scn = new SqlConnection())
            {
                scn.ConnectionString = connection;
                scn.Open();

                var updateRow = "UPDATE Customers set Postal_code='7532' where Customer_id=@Customer_id";
                SqlCommand sqlCommand = new SqlCommand(updateRow, scn);
                sqlCommand.Parameters.Add("@Customer_id", SqlDbType.Int).Value = id;
                var newCustomer = sqlCommand.ExecuteNonQuery();
                return newCustomer;
            }

        }
    }
}
