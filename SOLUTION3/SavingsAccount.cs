using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class SavingsAccount:Account
    {
        public float InterestRate { get; set; }

        public SavingsAccount(float balance, Customer customer, float interestRate)
            : base("Savings", balance, customer)
        {
            InterestRate = interestRate;
        }

        public override void Withdraw(float amount)
        {
            if (Balance - amount < 500)
            {
                throw new ArgumentException("Minimum balance requirement not met");
            }
            base.Withdraw(amount);
        }
    }
}
