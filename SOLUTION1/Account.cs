using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class Account
    {
        protected int accountNumber;
        protected string accountType;
        protected decimal accountBalance;

        // Default constructor
        public Account()
        {
        }

        // Parameterized constructor
        public Account(int accountNumber, string accountType, decimal accountBalance)
        {
            this.accountNumber = accountNumber;
            this.accountType = accountType;
            this.accountBalance = accountBalance;
        }

        // Getter and Setter methods
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        public decimal AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }

        // Deposit money into the account
        public void Deposit(decimal amount)
        {
            accountBalance += amount;
            Console.WriteLine($"Deposited ${amount} into account {accountNumber}. New balance: ${accountBalance}");
        }

        // Withdraw money from the account
        public virtual void Withdraw(decimal amount)
        {
            if (accountBalance >= amount)
            {
                accountBalance -= amount;
                Console.WriteLine($"Withdrew ${amount} from account {accountNumber}. New balance: ${accountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        // Calculate interest for savings accounts
        public virtual void CalculateInterest()
        {
            if (accountType == "Savings")
            {
                decimal interestRate = 0.045m;
                decimal interestAmount = accountBalance * interestRate;
                accountBalance += interestAmount;
                Console.WriteLine($"Added ${interestAmount} interest to account {accountNumber}. New balance: ${accountBalance}");
            }
            else
            {
                Console.WriteLine("Interest calculation only applicable for savings accounts.");
            }
        }

        // Print account information
        public void PrintAccountInfo()
        {
            Console.WriteLine("Account Information:");
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Account Balance: ${accountBalance}");
        }


        //TASK 8 - OVERLOADING METHODS

        // Overloaded deposit methods
        public virtual void Deposit(float amount)
        {
            accountBalance += (decimal)amount;
            Console.WriteLine($"Deposited ${amount} into account {accountNumber}. New balance: ${accountBalance}");
        }

        public virtual void Deposit(int amount)
        {
            accountBalance += amount;
            Console.WriteLine($"Deposited ${amount} into account {accountNumber}. New balance: ${accountBalance}");
        }

        public virtual void Deposit(double amount)
        {
            accountBalance += (decimal)amount;
            Console.WriteLine($"Deposited ${amount} into account {accountNumber}. New balance: ${accountBalance}");
        }

        // Overloaded withdraw methods
        public virtual void Withdraw(float amount)
        {
            if (accountBalance >= (decimal)amount)
            {
                accountBalance -= (decimal)amount;
                Console.WriteLine($"Withdrew ${amount} from account {accountNumber}. New balance: ${accountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public virtual void Withdraw(int amount)
        {
            if (accountBalance >= amount)
            {
                accountBalance -= amount;
                Console.WriteLine($"Withdrew ${amount} from account {accountNumber}. New balance: ${accountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public virtual void Withdraw(double amount)
        {
            if (accountBalance >= (decimal)amount)
            {
                accountBalance -= (decimal)amount;
                Console.WriteLine($"Withdrew ${amount} from account {accountNumber}. New balance: ${accountBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

    }
}
