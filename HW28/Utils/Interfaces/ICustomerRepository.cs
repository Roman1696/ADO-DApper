using System.Collections.Generic;
using Utils.Models;

namespace Utils
{
    public interface ICustomerRepository
    {
        IList<Customers> GetAllCustomers();
        int InsertCustomers(Customers customers);
        int UpdateCustomers(int id);
        int DeleteCustomers(int id);
    }
}
