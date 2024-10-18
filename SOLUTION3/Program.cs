using BankingApp;
using DAO_Library;
using Entity_Library;
using Exception_Library;
using static Exception_Library.Class1;


// Task 11: Interface/abstract class, and Single Inheritance, static variable
// Task 12: Exception Handling

internal class Program
{
    static void Main(string[] args)
    {
        // TASK11INTERFACE();

        // TASK 14 DB CONNECTION
        BankApp app = new BankApp();
        app.Run();

    }

    private static void TASK11INTERFACE()
    {
        BankServiceProviderImpl bank = new BankServiceProviderImpl();

        while (true)
        {
            try
            {
                Console.WriteLine("Banking System");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Exit");

                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CreateAccount(bank);
                        break;
                    case 2:
                        Deposit(bank);
                        break;
                    case 3:
                        Withdraw(bank);
                        break;
                    case 4:
                        GetBalance(bank);
                        break;
                    case 5:
                        Transfer(bank);
                        break;
                    case 6:
                        GetAccountDetails(bank);
                        break;
                    case 7:
                        ListAccounts(bank);
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverDraftLimitExcededException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    static void CreateAccount(BankServiceProviderImpl bank)
    {
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

        Customer customer = new Customer(customerId, customerName, email, phoneNumber, address);

        Console.WriteLine("Choose account type:");
        Console.WriteLine("1. Savings Account");
        Console.WriteLine("2. Current Account");
        Console.WriteLine("3. Zero Balance Account");

        Console.Write("Enter choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter initial balance: ");
                float balance = Convert.ToSingle(Console.ReadLine());
                Console.Write("Enter interest rate: ");
                float interestRate = Convert.ToSingle(Console.ReadLine());

                bank.CreateAccount(customer, 0, "Savings", balance);
                break;
            case 2:
                Console.Write("Enter initial balance: ");
                balance = Convert.ToSingle(Console.ReadLine());
                Console.Write("Enter overdraft limit: ");
                float overdraftLimit = Convert.ToSingle(Console.ReadLine());

                bank.CreateAccount(customer, 0, "Current", balance);
                break;
            case 3:
                bank.CreateAccount(customer, 0, "Zero Balance", 0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    static void Deposit(BankServiceProviderImpl bank)
    {
        Console.Write("Enter account number: ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());
        Console.Write("Enter deposit amount: ");
        float amount = Convert.ToSingle(Console.ReadLine());
        float balance = bank.Deposit(accountNumber, amount);
        Console.WriteLine($"Deposit successful. New balance: {balance}");
        
    }

    static void Withdraw(BankServiceProviderImpl bank)
    {
        Console.Write("Enter account number: ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());
        Console.Write("Enter withdrawal amount: ");
        float amount = Convert.ToSingle(Console.ReadLine());
        float balance = bank.Withdraw(accountNumber, amount);
        Console.WriteLine($"Withdrawal successful. New balance: {balance}");
        
       
    }

    static void GetBalance(BankServiceProviderImpl bank)
    {
        Console.Write("Enter account number: ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());
        float balance = bank.GetAccountBalance(accountNumber);
        Console.WriteLine($"Account balance: {balance}");
        
    }

    static void Transfer(BankServiceProviderImpl bank)
    {
        Console.Write("Enter source account number: ");
        long sourceAccountNumber = Convert.ToInt64(Console.ReadLine());
        Console.Write("Enter destination account number: ");
        long destinationAccountNumber = Convert.ToInt64(Console.ReadLine());
        Console.Write("Enter transfer amount: ");
        float amount = Convert.ToSingle(Console.ReadLine());
        float balance = bank.Transfer(sourceAccountNumber, destinationAccountNumber, amount);
        Console.WriteLine($"Transfer successful. New balance: {balance}");
        
        
    }

    static void GetAccountDetails(BankServiceProviderImpl bank)
    {
        Console.Write("Enter account number: ");
        long accountNumber = Convert.ToInt64(Console.ReadLine());
        string details = bank.GetAccountDetails(accountNumber);
        Console.WriteLine(details);
        
    }

    static void ListAccounts(BankServiceProviderImpl bank)
    {
        Account[] accounts = bank.ListAccounts();

        foreach (Account account in accounts)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}, Account Type: {account.AccountType}, Balance: {account.Balance}");
        }
    }
}