using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Library;

namespace BankingApp
{
    public class BankApp
    {
        private Bank bank;

        public BankApp()
        {
            bank = new Bank();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Banking System");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Account Details");
                Console.WriteLine("7. Exit");

                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        CheckBalance();
                        break;
                    case 5:
                        Transfer();
                        break;
                    case 6:
                        AccountDetails();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("Create Account");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");

            Console.Write("Choose account type: ");
            int accountType = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Customer customer = new Customer(customerId, customerName, "", email, phoneNumber, address);

            if (accountType == 1)
            {
                Console.Write("Enter initial balance: ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter interest rate: ");
                decimal interestRate = Convert.ToDecimal(Console.ReadLine());

                bank.CreateAccount(customer, "savings", balance);
            }
            else if (accountType == 2)
            {
                Console.Write("Enter initial balance: ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter overdraft limit: ");
                float overdraftLimit = Convert.ToSingle(Console.ReadLine());

                bank.CreateAccount(customer, "current", balance);
            }
        }

        private void Deposit()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter deposit amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            try
            {
                decimal balance = bank.Deposit(accountNumber, amount);
                Console.WriteLine($"Deposit successful. New balance: {balance}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Withdraw()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter withdrawal amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            try
            {
                decimal balance = bank.Withdraw(accountNumber, amount);
                Console.WriteLine($"Withdrawal successful. New balance: {balance}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CheckBalance()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());

            try
            {
                decimal balance = bank.GetAccountBalance(accountNumber);
                Console.WriteLine($"Account balance: {balance}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Transfer()
        {
            Console.Write("Enter source account number: ");
            long sourceAccountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter destination account number: ");
            long destinationAccountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter transfer amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            bank.Transfer(sourceAccountNumber, destinationAccountNumber, amount);
        }

        private void AccountDetails()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());

            bank.GetAccountDetails(accountNumber);
        }
    }
}
