using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Angul.DAL;
using System.Data.SqlClient;
using Angul.Models;
using System.Configuration;
using System.Collections;
using Microsoft.Extensions.Configuration;

namespace Angul.DAL
{
    public class CustomerRespository : ICustomerRepository
    {
        private readonly IDbConnection _db;
        private string connectionString;

        public CustomerRespository()
        {
            connectionString = @"Server=LAPTOP-3VJKFF09\OLORUNDARA;Database=MyLocalDB;Trusted_Connection=true;";

            //_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public List<Customer> GetCustomers(int amount, string sort)
        {
            return this.Connection.Query<Customer>("SELECT TOP " + amount + " [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive],[CustomerAddress] FROM [Customer] ORDER BY CustomerID " + sort).ToList();

        }

        public Customer GetSingleCustomer(int customerId)
        {
            return Connection.Query<Customer>("SELECT[CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive],[CustomerAddress] FROM [Customer] WHERE CustomerID =@CustomerID", new { CustomerID = customerId }).SingleOrDefault();

        }

        public bool InsertCustomer(Customer ourCustomer)
        {
            int rowsAffected = this.Connection.Execute(@"INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[IsActive],[CustomerAddress]) values (@CustomerFirstName, @CustomerLastName, @IsActive, @CustomerAddress)", new { CustomerFirstName = ourCustomer.CustomerFirstName, CustomerLastName = ourCustomer.CustomerLastName, IsActive = true, CustomerAddress = ourCustomer.CustomerAddress });

            if (rowsAffected > 0)
            {
                return true ;
            }
            return false;
        }

        public bool DeleteCustomer(int customerId)
        {
            int rowsAffected = this.Connection.Execute(@"DELETE FROM [Customer] WHERE CustomerID = @CustomerID", new { CustomerID = customerId });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer ourCustomer)
        {
            int rowsAffected = this.Connection.Execute("UPDATE [Customer] SET [CustomerFirstName] = @CustomerFirstName ,[CustomerLastName] = @CustomerLastName, [IsActive] = @IsActive, [CustomerAddress] = @CustomerAddress WHERE CustomerID = " + ourCustomer.CustomerID, ourCustomer);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}