using Entity_Library;
using Entity_Library_More;

internal class Program
{
    private static void Main(string[] args)
    {
        // TASK1ConditionalStatements();

        // TASK2NestedConditionalStatements();

        // TASK3LoopStructures();

        // TASK4ArrayDataValidation();

        // TASK5PasswordValidation();

        // TASK6TransactionsWithHistory();

        // TASK7ClassAndObject();

        // TASK8InheritanceAndPloymorphism();
        // return;
        
        TASK9Abstraction();
        // return;



        Console.ReadKey();
    }

    private static void TASK9Abstraction()
    {
        BankAccount account = null;

        Console.WriteLine("Banking System");
        Console.WriteLine("1. Create Savings Account");
        Console.WriteLine("2. Create Current Account");

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter account number: ");
                int accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter customer name: ");
                string customerName = Console.ReadLine();
                Console.Write("Enter initial balance: ");
                decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter interest rate: ");
                decimal interestRate = Convert.ToDecimal(Console.ReadLine());

                account = new Entity_Library_More.SavingsAccount(accountNumber, customerName, initialBalance, interestRate);
                break;
            case 2:
                Console.Write("Enter account number: ");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter customer name: ");
                customerName = Console.ReadLine();
                Console.Write("Enter initial balance: ");
                initialBalance = Convert.ToDecimal(Console.ReadLine());

                account = new Entity_Library_More.CurrentAccount(accountNumber, customerName, initialBalance);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        while (true)
        {
            Console.WriteLine("\nAccount Menu");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Calculate Interest");
            Console.WriteLine("4. Display Account Info");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter amount to deposit: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;
                case 2:
                    Console.Write("Enter amount to withdraw: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    break;
                case 3:
                    account.CalculateInterest();
                    break;
                case 4:
                    account.PrintAccountInfo();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void TASK8InheritanceAndPloymorphism()
    {
        // Display banking system menu
        Console.WriteLine("Banking System");
        Console.WriteLine("1. Create Savings Account");
        Console.WriteLine("2. Create Current Account");

        // Get user choice
        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Account account = null;

        // Create account based on user choice
        switch (choice)
        {
            case 1:
                // Create SavingsAccount
                Console.Write("Enter account number: ");
                int accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter initial balance: ");
                decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter interest rate: ");
                decimal interestRate = Convert.ToDecimal(Console.ReadLine());

                account = new Entity_Library.SavingsAccount(accountNumber, initialBalance, interestRate);
                break;
            case 2:
                // Create CurrentAccount
                Console.Write("Enter account number: ");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter initial balance: ");
                initialBalance = Convert.ToDecimal(Console.ReadLine());

                account = new Entity_Library.CurrentAccount(accountNumber, initialBalance);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        // Perform account operations
        while (true)
        {
            Console.WriteLine("\nAccount Menu");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Calculate Interest");
            Console.WriteLine("4. Display Account Info");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter amount to deposit: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;
                case 2:
                    Console.Write("Enter amount to withdraw: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    break;
                case 3:
                    if (account is Entity_Library.SavingsAccount)
                    {
                        ((Entity_Library.SavingsAccount)account).CalculateInterest();
                    }
                    else
                    {
                        Console.WriteLine("Interest calculation only applicable for savings accounts.");
                    }
                    break;
                case 4:
                    account.PrintAccountInfo();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void TASK7ClassAndObject()
    {
        // Create customer object
        Customer customer = new Customer(1, "Avni", "Jain", "avni.jain@example.com", "1234567890", "123 Main St");
        customer.PrintCustomerInfo();

        // Create account object
        Account account = new Account(1234, "Savings", 1000.00m);
        account.PrintAccountInfo();

        // Deposit money into the account
        account.Deposit(500.00m);

        // Withdraw money from the account
        account.Withdraw(200.00m);

        // Calculate interest for savings account
        account.CalculateInterest();
    }

    private static void TASK6TransactionsWithHistory()
    {
        string transactionHistory = "";
        decimal balance = 0;

        bool continueTransactions = true;
        while (continueTransactions)
        {
            Console.WriteLine("Bank Transaction Manager");
            Console.WriteLine("1. Add Deposit");
            Console.WriteLine("2. Add Withdrawal");
            Console.WriteLine("3. Exit and View Transaction History");

            Console.Write("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter deposit amount: $");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    balance += depositAmount;
                    transactionHistory += $"Deposit: +${depositAmount}\n";
                    Console.WriteLine($"Deposit added successfully. New balance: ${balance}");
                    break;
                case 2:
                    Console.Write("Enter withdrawal amount: $");
                    decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

                    if (withdrawalAmount > balance)
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                    else
                    {
                        balance -= withdrawalAmount;
                        transactionHistory += $"Withdrawal: -${withdrawalAmount}\n";
                        Console.WriteLine($"Withdrawal successful. New balance: ${balance}");
                    }
                    break;
                case 3:
                    continueTransactions = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }

        Console.WriteLine("\nTransaction History:");
        Console.WriteLine(transactionHistory);
        Console.WriteLine($"Final balance: ${balance}");
    }

    private static void TASK5PasswordValidation()
    {
        Console.WriteLine("Create a password for your bank account");

        while (true)
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (ValidatePassword(password))
            {
                Console.WriteLine("Password is valid.");
                break;
            }
            else
            {
                Console.WriteLine("Password is not valid. Please ensure:");
                Console.WriteLine("  - At least 8 characters long");
                Console.WriteLine("  - Contains at least one uppercase letter");
                Console.WriteLine("  - Contains at least one digit");

            }
        }

        static bool ValidatePassword(string password)
        {
            // Check password length
            if (password.Length < 8)
                return false;

            // Check for uppercase letter
            if (!password.Any(char.IsUpper))
                return false;

            // Check for digit
            if (!password.Any(char.IsDigit))
                return false;

            return true;
        }
    }

    private static void TASK4ArrayDataValidation()
    {
        // Initialize customer account data
        int[] accountNumbers = { 1234, 5678, 9012 };
        decimal[] balances = { 1000.00m, 5000.00m, 2000.00m };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Bank Account Balance Checker");
            Console.Write("Enter your account number (or -1 to exit): ");
            string inputAccountNumber = Console.ReadLine();

            // Validate account number
            if (int.TryParse(inputAccountNumber, out int accountNumber))
            {
                if (accountNumber == -1)
                {
                    break;
                }

                for (int i = 0; i < accountNumbers.Length; i++)
                {
                    if (accountNumber == accountNumbers[i])
                    {
                        Console.WriteLine($"Account balance: ${balances[i]:F2}");
                        Console.ReadKey();
                        break;
                    }
                }

                if (accountNumber != accountNumbers[0] && accountNumber != accountNumbers[1] && accountNumber != accountNumbers[2])
                {
                    Console.WriteLine("Invalid account number. Please try again.");
                    Console.ReadKey();
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid account number.");
                Console.ReadKey();
                break;
            }
        }
    }

    private static void TASK3LoopStructures()
    {
        Console.WriteLine("Compound Interest Calculator");

        // Get number of customers
        Console.Write("Enter the number of customers: ");
        int numCustomers = Convert.ToInt32(Console.ReadLine());

        // Loop through each customer
        for (int i = 1; i <= numCustomers; i++)
        {
            Console.WriteLine($"\nCustomer {i} Information:");

            // Getting initial balance, annual interest rate, and years
            Console.Write("Enter initial balance: $");
            decimal initialBalance = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter annual interest rate (%): ");
            decimal annualInterestRate = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter number of years: ");
            int years = Convert.ToInt32(Console.ReadLine());

            // Calculate future balance
            decimal futureBalance = initialBalance * (decimal)Math.Pow((double)(1 + annualInterestRate / 100), years);

            // Display future balance
            Console.WriteLine($"Future balance after {years} years: ${futureBalance:F2}");
        }
    }

    private static void TASK2NestedConditionalStatements()
    {
        Console.WriteLine("Welcome to ATM Transaction Simulator!");

        // Get initial balance from user
        Console.Write("Enter your current balance: $");
        decimal balance = Convert.ToDecimal(Console.ReadLine());

        // Display transaction options
        Console.WriteLine("\nTransaction Options:");
        Console.WriteLine("1. Check Balance");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Deposit");
        Console.Write("Choose an option (1/2/3): ");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:   // Check Balance

                Console.WriteLine($"Your current balance is: ${balance}");
                break;

            case 2:   // Withdraw Amount

                Console.Write("Enter amount to withdraw: $");
                decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

                if (withdrawAmount > balance)
                {
                    Console.WriteLine("Insufficient funds.");
                }
                else if (withdrawAmount % 100 != 0 && withdrawAmount % 500 != 0)
                {
                    Console.WriteLine("Withdrawal amount must be in multiples of 100 or 500.");
                }
                else
                {
                    balance -= withdrawAmount;
                    Console.WriteLine($"Withdrawal successful. New balance: ${balance}");
                }
                break;

            case 3:    // Deposit Amount

                Console.Write("Enter amount to deposit: $");
                decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

                balance += depositAmount;
                Console.WriteLine($"Deposit successful. New balance: ${balance}");
                break;

            default:

                Console.WriteLine("Invalid option. Please choose again.");
                break;

        }
    }

    private static void TASK1ConditionalStatements()
    {
        // Take customer's credit score and annual income as input
        Console.Write("Enter your credit score: ");
        int creditScore = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your annual income: $");
        decimal annualIncome = Convert.ToDecimal(Console.ReadLine());

        // Using conditional statements to determine loan eligibility
        if (creditScore >= 700 && annualIncome >= 50000)
        {
            Console.WriteLine("Congratulations! You are eligible for a loan.");
        }
        else
        {
            Console.WriteLine("Sorry, you are not eligible for a loan.");
            if (creditScore < 700)
            {
                Console.WriteLine("Your credit score is too low. Minimum required is 700.");
            }
            if (annualIncome < 50000)
            {
                Console.WriteLine("Your annual income is too low. Minimum required is $50,000.");
            }
        }
    }
}