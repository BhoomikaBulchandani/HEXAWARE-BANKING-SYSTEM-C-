using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Library;
using Exception_Library;
using static Exception_Library.Class1;


namespace DAO_Library
{
    public class BankServiceProviderImpl:CustomerServiceProviderImpl, IBankServiceProvider
    {   

        // FOR TASK 14 THE LIST OF ACCOUNTS AND TRANSACTIONS ARE MADE ALONG WITH BRANCHNAME AND ADDRESS

        public List<Account> accountList { get; set; }
        public List<Transaction> transactionList { get; set; }
        public string branchName { get; set; }
        public string branchAddress { get; set; }

        public BankServiceProviderImpl()
        {
            accountList = new List<Account>();
            transactionList = new List<Transaction>();
        }

        public void CreateAccount(Customer customer, long accNo, string accType, float balance)
        {
            var account = new Account(accType, balance, customer);
            accountList.Add(account);
             
        }

        public Account[] ListAccounts()
        {
            return accountList.ToArray();
        }

        public string GetAccountDetails(long accountNumber)
        {
            return base.GetAccountDetails(accountNumber);
        }

        public void CalculateInterest()
        {
            foreach (var account in accountList)
            {
                // Calculate interest based on balance and interest rate
                account.Balance += account.Balance * 0.05f; // 5% interest rate
            }
        }

        // BELOW IS IMPLEMENTATION FOR TASK 11 

        //public void CreateAccount(Customer customer, long accNo, string accType, float balance)
        //{
        //    Account account = null;

        //    if (customer == null)
        //    {
        //        throw new NullReferenceExceptionBank();
        //    }

        //    if (accType == "Savings")
        //    {
        //        account = new SavingsAccount(balance, customer, 0.05f);
        //    }
        //    else if (accType == "Current")
        //    {
        //        account = new CurrentAccount(balance, customer, 1000);
        //    }
        //    else if (accType == "Zero Balance")
        //    {
        //        account = new ZeroBalanceAccount(customer);
        //    }


        //    accounts[accountIndex] = account;
        //    accountIndex++;
        //}

        //public Account[] ListAccounts()
        //{
        //    Account[] listedAccounts = new Account[accountIndex];
        //    Array.Copy(accounts, listedAccounts, accountIndex);
        //    return listedAccounts;
        //}

        //public float CalculateInterest()
        //{
        //    float totalInterest = 0;

        //    for (int i = 0; i < accountIndex; i++)
        //    {
        //        if (accounts[i] is SavingsAccount)
        //        {
        //            SavingsAccount savingsAccount = (SavingsAccount)accounts[i];
        //            totalInterest += savingsAccount.Balance * savingsAccount.InterestRate * 0.01f;
        //        }
        //    }
        //    return totalInterest;
        //}

        //public string GetAccountDetails(long accountNumber)
        //{
        //    return base.GetAccountDetails(accountNumber);
        //}

    }
}
