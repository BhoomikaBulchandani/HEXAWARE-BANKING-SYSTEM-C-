using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity_Library;

namespace DAO_Library
{
    public interface IBankServiceProvider:ICustomerServiceProvider
    {
        void CreateAccount(Customer customer, long accNo, string accType, float balance);
        Account[] ListAccounts();
         string GetAccountDetails(long accountNumber);
        void CalculateInterest();
    }
}
