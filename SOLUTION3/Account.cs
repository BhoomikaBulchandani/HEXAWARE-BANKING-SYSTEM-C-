using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class Account
    {
        private static long lastAccNo = 0;
        public long AccountNumber { get; }
        public string AccountType { get; set; }
        public float Balance { get; set; }
        public Customer Customer { get; set; }

        public Account(string accountType, float balance, Customer customer)
        {
            AccountNumber = ++lastAccNo;
            AccountType = accountType;
            Balance = balance;
            Customer = customer;
        }

        public virtual void Deposit(float amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(float amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new ArgumentException("Insufficient funds");
            }
        }
    }
}
