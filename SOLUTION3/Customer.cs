using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer(int customerId, string customerName, string email, string phoneNumber, string address)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
