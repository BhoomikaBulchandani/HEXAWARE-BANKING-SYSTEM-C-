using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library_More
{
    public class SavingsAccount:BankAccount
    {
        private decimal interestRate;

        // Parameterized Constructor
        public SavingsAccount(int accountNumber, string customerName, decimal balance, decimal interestRate)
            : base(accountNumber, customerName, balance)
        {
            this.interestRate = interestRate;
        }

        // Implement Deposit Method
        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount} into Savings Account {AccountNumber}. New balance: ${Balance}");
        }

        // Implement Withdraw Method
        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew ${amount} from Savings Account {AccountNumber}. New balance: ${Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        // Implement Calculate Interest Method
        public override void CalculateInterest()
        {
            decimal interestAmount = Balance * interestRate * 0.01m;
            Balance += interestAmount;
            Console.WriteLine($"Added ${interestAmount} interest to Savings Account {AccountNumber}. New balance: ${Balance}");
        }
    }
}
