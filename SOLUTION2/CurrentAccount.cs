using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class CurrentAccount:Account
    {
        private const decimal overdraftLimit = 1000.00m;
        private decimal currentOverdraft;

        // Parameterized Constructor
        public CurrentAccount(long accountNumber, string accountType, Customer customer, decimal balance)
            : base(accountNumber, accountType, balance, customer)
        {
            currentOverdraft = 100.00m;
        }

        // Implement Deposit Method
        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount} into Current Account {AccountNumber}. New balance: ${Balance}");
        }

        // Implement Withdraw Method
        public override void Withdraw(decimal amount)
        {
            if (Balance + currentOverdraft >= amount)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                }
                else
                {
                    decimal overdraftAmount = amount - Balance;
                    Balance = 0.00m;
                    currentOverdraft += overdraftAmount;
                }
                Console.WriteLine($"Withdrew ${amount} from Current Account {AccountNumber}. New balance: ${Balance}");
                Console.WriteLine($"Current overdraft: ${currentOverdraft}");
            }
            else
            {
                Console.WriteLine("Withdrawal exceeds overdraft limit.");
            }
        }

        // Implement Calculate Interest Method
        public override void CalculateInterest()
        {
            Console.WriteLine("No interest applicable for Current Account.");
        }
    }
}
