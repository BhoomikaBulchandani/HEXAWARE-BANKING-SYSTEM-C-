using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Entity_Library;
using Exception_Library;
using static Exception_Library.Class1;


namespace DAO_Library
{
    public class CustomerServiceProviderImpl:ICustomerServiceProvider
    {
        public Account[] accounts = new Account[100];
        public int accountIndex = 0;

        public float GetAccountBalance(long accountNumber)
        {
            for (int i = 0; i < accountIndex; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    return accounts[i].Balance;
                }
            }
            throw new ArgumentException("Account not found");
        }

        public float Deposit(long accountNumber, float amount)
        {
            for (int i = 0; i < accountIndex; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    accounts[i].Deposit(amount);
                    return accounts[i].Balance;
                }
            }
            throw new ArgumentException("Account not found");
        }

        public float Withdraw(long accountNumber, float amount)
        {
            for (int i = 0; i < accountIndex; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    accounts[i].Withdraw(amount);
                    return accounts[i].Balance;
                }

                if (accounts[i].Balance < amount)
                {
                    throw new InsufficientFundException();
                }
            }
            throw new InvalidAccountException();
        }

        public float Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            Account fromAccount = null;
            Account toAccount = null;

            for (int i = 0; i < accountIndex; i++)
            {
                if (accounts[i].AccountNumber == fromAccountNumber)
                {
                    fromAccount = accounts[i];
                }
                else if (accounts[i].AccountNumber == toAccountNumber)
                {
                    toAccount = accounts[i];
                }
            }

            if (fromAccount == null || toAccount == null)
            {
                throw new InvalidAccountException();
            }

            if (fromAccount.Balance < amount)
            {
                throw new InsufficientFundException();
            }

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

            return fromAccount.Balance;
        }

        public string GetAccountDetails(long accountNumber)
        {
            for (int i = 0; i < accountIndex; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    return $"Account Number: {accounts[i].AccountNumber}, Account Type: {accounts[i].AccountType}, Balance: {accounts[i].Balance}";
                }
            }
            throw new InvalidAccountException();
        }


        public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            // Assume transactions are stored in a separate list
            var transactions = new List<Transaction>();
            // Filter transactions by account number and date range
            return transactions;
        }
    }
}
