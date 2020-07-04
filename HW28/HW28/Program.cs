using System;
using BusinessLogicApp;
using Utils.Models;

namespace HW28
{
    class Program
    {
        public static void Main(string[] args)
        {
            var customerManager = new CustomerManager();

            var customers = customerManager.GetAllCustomers();

            foreach(var customer in customers)
            {
                Console.WriteLine(customer);
                
            }
            Console.WriteLine(customerManager.DeleteCustomers(2));
            Console.WriteLine(customerManager.InsertCustomers(new Customers(3,"dfsdf","sdfsdf","sfdsfs","rrr","4rsd4")));
            Console.WriteLine(customerManager.UpdateCustomers(1));


            Console.ReadKey();
        }
    }
}
