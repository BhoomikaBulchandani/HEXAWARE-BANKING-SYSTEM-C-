using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Library
{
    public class Transaction
    {

        public int TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public float Amount { get; set; }

        public Transaction(int transactionId, long accountNumber, DateTime transactionDate, string transactionType, float amount)
        {
            TransactionId = transactionId;
            AccountNumber = accountNumber;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            Amount = amount;
        }

        //public Account Account { get; set; }
        //public string Description { get; set; }
        //public DateTime DateTime { get; set; }
        //public TransactionType Type { get; set; }
        //public float TransactionAmount { get; set; }

        //public enum TransactionType
        //{
        //    Withdraw,
        //    Deposit,
        //    Transfer
        //}

        //public Transaction(Account account, string description, TransactionType type, float transactionAmount)
        //{
        //    Account = account;
        //    Description = description;
        //    DateTime = DateTime.Now;
        //    Type = type;
        //    TransactionAmount = transactionAmount;
        //}

        //public override string ToString()
        //{
        //    return $"Transaction ID: {Guid.NewGuid()}\nAccount Number: {Account.AccountNumber}\nDescription: {Description}\nDate and Time: {DateTime}\nTransaction Type: {Type}\nTransaction Amount: {TransactionAmount}";
        //}
    }
}
