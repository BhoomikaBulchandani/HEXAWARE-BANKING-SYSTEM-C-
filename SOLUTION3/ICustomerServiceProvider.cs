using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Library;


namespace DAO_Library
{
    public interface ICustomerServiceProvider
    {
        float GetAccountBalance(long accountNumber);
        float Deposit(long accountNumber, float amount);
        float Withdraw(long accountNumber, float amount);
        float Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        string GetAccountDetails(long accountNumber);

        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}
