namespace Entity_Library_More
{
    public abstract class BankAccount
    {
        private int accountNumber;
        private string customerName;
        private decimal balance;

        // Default Constructor
        public BankAccount() { }

        // Parameterized Constructor
        public BankAccount(int accountNumber, string customerName, decimal balance)
        {
            this.accountNumber = accountNumber;
            this.customerName = customerName;
            this.balance = balance;
        }

        // Getters and Setters
        public int AccountNumber { get { return accountNumber; } set { accountNumber = value; } }
        public string CustomerName { get { return customerName; } set { customerName = value; } }
        public decimal Balance { get { return balance; } set { balance = value; } }

        // Abstract Methods
        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
        public abstract void CalculateInterest();

        // Print Account Information
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Balance: {balance}");
        }
    }
}
