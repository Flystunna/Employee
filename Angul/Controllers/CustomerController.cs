using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Angul.Models;
using Angul.DAL;

namespace Angul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private CustomerRespository _ourCustomerRespository;
        public CustomerController()
        {
            _ourCustomerRespository = new CustomerRespository();
        }

        [Route("Customers")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ourCustomerRespository.GetCustomers(10, "ASC"));
        }
        // GET: /Customer/10/ASC
        [Route("Customers/{amount}/{sort}")]
        [HttpGet]
        public List<Customer> Get(int amount, string sort)
        {
            return _ourCustomerRespository.GetCustomers(amount, sort);
        }
        // GET: /Customer/5
        [Route("Customers/{id}")]
        [HttpGet]
        public Customer Get(int id)
        {
            return _ourCustomerRespository.GetSingleCustomer(id);
        }
      // POST: /Customer
        [Route("Customers")]
        [HttpPost]
        public IActionResult Post([FromBody]Customer ourCustomer)
        {
            //return true;
            return Ok(_ourCustomerRespository.InsertCustomer(ourCustomer));
        }
        // PUT: api/Customer/5
        [Route("Customers")]
        [HttpPut]
        public IActionResult Put([FromBody]Customer ourCustomer)
        {
            return Ok(_ourCustomerRespository.UpdateCustomer(ourCustomer));
        }

        // DELETE: api/Customer/5
        [Route("Customers/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)

        {

            return Ok(_ourCustomerRespository.DeleteCustomer(id));

        }

    }

}