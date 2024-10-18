using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class ZeroBalanceAccount:Account
    {
        public ZeroBalanceAccount(Customer customer)
        : base("Zero Balance", 0, customer)
        {
        }
    }
}
