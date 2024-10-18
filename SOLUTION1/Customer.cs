using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class Customer
    {
        private int customerId;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string phoneNumber;
        private string address;

        // Default constructor
        public Customer()
        {
        }

        // Parameterized constructor
        public Customer(int customerId, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        // Getter and Setter methods
        public int CustomerId
        {
            get { return customerId; }              
            set { customerId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // Print customer information
        public void PrintCustomerInfo()
        {
            Console.WriteLine("Customer Information:");
            Console.WriteLine($"Customer ID: {customerId}");
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Email Address: {emailAddress}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Address: {address}");
        }
    }
}
