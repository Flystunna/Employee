using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angul.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public bool IsActive { get; set; }
        public string CustomerAddress { get; set; }
    }
}
