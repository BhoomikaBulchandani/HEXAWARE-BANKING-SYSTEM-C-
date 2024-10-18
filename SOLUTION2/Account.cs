using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public abstract class Account
    {
        protected long accountNumber;
        protected string accountType;
        protected decimal balance;
        protected Customer customer;

        // Default Constructor
        public Account() { }

        // Parameterized Constructor
        public Account(long accountNumber, string accountType, decimal balance, Customer customer)
        {
            this.accountNumber = accountNumber;
            this.accountType = accountType;
            this.balance = balance;
            this.customer = customer;
        }

        // Getters and Setters
        public long AccountNumber { get { return accountNumber; } set { accountNumber = value; } }
        public string AccountType { get { return accountType; } set { accountType = value; } }
        public decimal Balance { get { return balance; } set { balance = value; } }
        public Customer Customer { get { return customer; } set { customer = value; } }

        // Abstract Methods
        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
        public abstract void CalculateInterest();

        // Print Account Information
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Balance: {balance}");
            customer.PrintCustomerInfo();
        }

    }
}
