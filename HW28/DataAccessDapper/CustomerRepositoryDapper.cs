using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Utils;
using Utils.Models;

namespace DataAccessDapper
{
    public class CustomerRepositoryDapper : ICustomerRepository
    {
        private readonly string connection = string.Empty;
        public CustomerRepositoryDapper()
        {
            connection = ConfigurationManager.ConnectionStrings["HRSQLService"].ConnectionString;
        }
        //public int DeleteCustomer(int id)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connection))
        //    {
        //        var deleteQuery = "Delete from Customers where Customer_id = @id";

        //        var numbOfAffectedRows = sqlConnection.Execute(deleteQuery, new { id = id });
        //        return numbOfAffectedRows;
        //    }
        //}

        //public IList<Customers> GetAllCustomers()
        //{
        //    using(SqlConnection sqlConnection = new SqlConnection(connection))
        //    {
        //        var selection = "Select Customer_name,Country,City,Region,Postal_code from Customers";

        //        var customers = sqlConnection.Query<Customers>(selection).AsList();
        //        return customers;
        //    }
        //}

        ////public Customers GetCustomersById(int id)
        ////{
        ////    using (SqlConnection sqlConnection = new SqlConnection(connection))
        ////    {
        ////        var showById = "SELECT From Customers Where Customer_id=@id";

        ////    }
        ////}
        //public Customers GetCustomersById(int id)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connection))
        //    {
        //        var showById = sqlConnection.Query<Customers>("SELECT * From Customers Where Customer_id=@id");
        //        return showById.AsList().ForEach(Console.WriteLine);
        //    }
        //}

        //public int InsertCustomer(Customers customers)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(connection))
        //    {

        //        var insertQuery = "Insert into Customers(Customer_name,Country,City,region,Postal_code)" +
        //            "Values(@Customer_name,@Country,@City,@region,Postal_code)";

        //        var numbOfAffectedRowsIns = sqlConnection.Execute(insertQuery,customers);
        //        return numbOfAffectedRowsIns;
        //    }
        //}

        IList<Customers> ICustomerRepository.GetAllCustomers()
        {
            List<Customers> customers = new List<Customers>();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                customers = sqlConnection.Query<Customers>("Select Customer_name,Country,City,Region,Postal_code from Customers").ToList();
                sqlConnection.Close();
            }
            return customers;
        }

        int ICustomerRepository.InsertCustomers(Customers customers)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                var affectedRows = sqlConnection.Execute(
                    "Insert into Customers(Customer_name,Country,City,Region,Postal_code)" +
                    "values (@Customer_name,@Country,@City,@Region,@Postal_code)",
                    new
                    {
                        Customer_name = customers.Customer_name,
                        Country = customers.Country,
                        City = customers.City,
                        Region = customers.Region,
                        Postal_code = customers.Postal_code
                    });
                sqlConnection.Close();
                return affectedRows;
            }
        }

        int ICustomerRepository.UpdateCustomers(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                var affectedRows = sqlConnection.Execute(
                   "UPDATE Customers set Postal_code='7532' where Customer_id=@Customer_id", new { Customer_id = id });
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public int DeleteCustomers(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                var affectedRows = sqlConnection.Execute("Delete from Customers Where Customer_id = @Customer_id", new { Customer_id = id });
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}
