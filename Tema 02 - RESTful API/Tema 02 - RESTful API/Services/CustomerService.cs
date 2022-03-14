using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CustomerService
    {
        static List<Customer> Customers { get; }
        static CustomerService()
        {
            Customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Marius"},
            new Customer { Id = 2, Name = "Catalin"},
            new Customer { Id = 3, Name = "Monica"},
            new Customer { Id = 4, Name = "Iulia"}

        };
        }

        public static List<Customer> GetAll() => Customers;

        public static Customer GetById(int id) => Customers.Find(p => p.Id == id);


    }
}
