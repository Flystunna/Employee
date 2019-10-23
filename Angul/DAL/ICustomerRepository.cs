using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Angul.Models;

namespace Angul.DAL
{
    internal interface ICustomerRepository
    {
        List<Customer> GetCustomers(int amount, string sort);

        Customer GetSingleCustomer(int customerId);

        bool InsertCustomer(Customer ourCustomer);

        bool DeleteCustomer(int customerId);

        bool UpdateCustomer(Customer ourCustomer);
    }
}
