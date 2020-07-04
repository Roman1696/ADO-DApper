using System.Collections.Generic;
using DataAccessDapper;
using Utils;
using Utils.Models;

namespace BusinessLogicApp
{
    public class CustomerManager
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerManager()
        {
            customerRepository = new CustomerRepositoryDapper();
                //new CustomerRepositoryADO();
        }
        public IList<Customers> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }
        public int DeleteCustomers(int id)
        {
            return customerRepository.DeleteCustomers(id);
        }
        public int InsertCustomers(Customers customers)
        {
            return customerRepository.InsertCustomers(customers);
        }
        public int UpdateCustomers(int id)
        {
            return customerRepository.UpdateCustomers(id);
        }
    }
}
