using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class Bank
    {
        private static long accountNumberCounter = 1001;
        private Dictionary<long, Account> accounts;

        public decimal interestRate { get; private set; }

        public Bank()
        {
            accounts = new Dictionary<long, Account>();
        }

        public long CreateAccount(Customer customer, string accountType, decimal balance)
        {
            long accountNumber = accountNumberCounter++;
            Account account;

            if (accountType == "Savings")
            {
                account = new SavingsAccount(accountNumber, accountType, balance, customer, interestRate);
            }
            else if (accountType == "Current")
            {
                account = new CurrentAccount(accountNumber, accountType, customer, balance);
            }
            else
            {
                throw new ArgumentException("Invalid account type");
            }

            accounts.Add(accountNumber, account);
            return accountNumber;
        }

        public decimal GetAccountBalance(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].Balance;
            }
            else
            {
                throw new ArgumentException("Account not found");
            }
        }

        public decimal Deposit(long accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber].Deposit(amount);
                return accounts[accountNumber].Balance;
            }
            else
            {
                throw new ArgumentException("Account not found");
            }
        }

        public decimal Withdraw(long accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber].Withdraw(amount);
                return accounts[accountNumber].Balance;
            }
            else
            {
                throw new ArgumentException("Account not found");
            }
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, decimal amount)
        {
            if (accounts.ContainsKey(fromAccountNumber) && accounts.ContainsKey(toAccountNumber))
            {
                accounts[fromAccountNumber].Withdraw(amount);
                accounts[toAccountNumber].Deposit(amount);
            }
            else
            {
                throw new ArgumentException("One or both accounts not found");
            }
        }

        public void GetAccountDetails(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber].PrintAccountInfo();
            }
            else
            {
                throw new ArgumentException("Account not found");
            }
        }
    }
}
