using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class CurrentAccount:Account
    {
        public float OverdraftLimit { get; set; }

        public CurrentAccount(float balance, Customer customer, float overdraftLimit)
            : base("Current", balance, customer)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Withdraw(float amount)
        {
            if (Balance - amount < -OverdraftLimit)
            {
                throw new ArgumentException("Overdraft limit exceeded");
            }
            base.Withdraw(amount);
        }
    }
}
