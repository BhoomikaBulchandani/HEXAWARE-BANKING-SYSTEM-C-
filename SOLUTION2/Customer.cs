using System;
using System.Text.RegularExpressions;


namespace Entity_Library
{
    public class Customer
    {
        private long customerId;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string phoneNumber;
        private string address;

        // Default Constructor
        public Customer() { }

        // Parameterized Constructor
        public Customer(long customerId, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        // Getters and Setters
        public long CustomerId { get { return customerId; } set { customerId = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string EmailAddress { get { return emailAddress; } set { emailAddress = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }

        // Validate Email Address
        public bool IsValidEmail()
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(emailAddress);
        }

        // Validate Phone Number
        public bool IsValidPhoneNumber()
        {
            var phoneRegex = new Regex(@"^\d{10}$");
            return phoneRegex.IsMatch(phoneNumber);
        }

        // Print Customer Information
        public void PrintCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {customerId}");
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Email Address: {emailAddress}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Address: {address}");
        }

    }
}
