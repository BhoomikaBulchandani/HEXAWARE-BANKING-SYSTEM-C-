using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity_Library;
using Microsoft.Data.SqlClient;
using Utility_Library;


namespace DAO_Library
{
    public class BankRepositoryImpl:IBankRepository
    {
        //private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=HMBank;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public long CreateAccount(Customer customer, string accType, float balance)
        {
            long accountNumber = GenerateAccountNumber();

            try
            {
                using (SqlConnection conn = DBUtil.getDBConn())
                //using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (conn != null)
                    {

                        string query = "INSERT INTO Accounts (AccountNumber, AccountType, Balance, CustomerId) VALUES (@accNo, @accType, @balance, @customerId)";
                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.AddWithValue("@accNo", accountNumber);
                        command.Parameters.AddWithValue("@accType", accType);
                        command.Parameters.AddWithValue("@balance", balance);
                        command.Parameters.AddWithValue("@customerId", customer.CustomerId);
                        command.ExecuteNonQuery();

                    }
                }
                return accountNumber;
            }
            catch(SqlException ex)
            {
                throw new Exception("Error creating account: " + ex.Message);
            }
        }

        // Helper method to generate a new account number
        private long GenerateAccountNumber()
        {
            // Implement a logic to generate a unique account number (e.g., using a sequence or GUID)
            // For simplicity, let's use a random number
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        public List<Account> ListAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection conn = DBUtil.getDBConn())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM Accounts";
                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    
                }
            }
            return accounts;
        }

        public void CalculateInterest()
        {
            using (SqlConnection conn = DBUtil.getDBConn())
            {
                if (conn != null)
                {
                    string query = "UPDATE Accounts SET Balance = Balance * 1.05";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                }
            }
        }

        public float GetAccountBalance(long accountNumber)
        {
            float balance = 0;
            using (SqlConnection conn = DBUtil.getDBConn())
            {
                if (conn != null)
                {
                    string query = "SELECT Balance FROM Accounts WHERE AccountNumber = @accNo";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@accNo", accountNumber);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        balance = Convert.ToSingle(reader["Balance"]);
                    }
                }
            }
            return balance;
        }

        public float Deposit(long accountNumber, float amount)
        {
            using (SqlConnection conn = DBUtil.getDBConn())
            {
                if (conn != null)
                {
                    string query = "UPDATE Accounts SET Balance = Balance + @amount WHERE AccountNumber = @accNo";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@accNo", accountNumber);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.ExecuteNonQuery();
                }
            }
            return GetAccountBalance(accountNumber);
        }

        public float Withdraw(long accountNumber, float amount)
        {
            using (SqlConnection conn = DBUtil.getDBConn())
            {
                if (conn != null)
                {
                    string query = "UPDATE Accounts SET Balance = Balance - @amount WHERE AccountNumber = @accNo";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@accNo", accountNumber);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.ExecuteNonQuery();
                }
            }
            return GetAccountBalance(accountNumber);
        }

        public float Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            Deposit(toAccountNumber, amount);
            Withdraw(fromAccountNumber, amount);
            return GetAccountBalance(fromAccountNumber);
        }

        public Account GetAccountDetails(long accountNumber)
        {
            Account account = null;
            using (SqlConnection conn = DBUtil.getDBConn())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM Accounts WHERE AccountNumber = @accNo";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@accNo", accountNumber);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = GetCustomer(Convert.ToInt32(reader["CustomerId"]));
                        account = new Account(
                            reader["AccountType"].ToString(),
                            Convert.ToSingle(reader["Balance"]),
                            customer);
                    }
                }
            }
            return account;
        }

        public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (SqlConnection conn = DBUtil.getDBConn())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM Transactions WHERE AccountNumber = @accNo AND TransactionDate BETWEEN @fromDate AND @toDate";
                    SqlCommand command = new SqlCommand(query, conn); // Declare and initialize command here
                    command.Parameters.AddWithValue("@accNo", accountNumber);
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    SqlDataReader reader = command.ExecuteReader(); // Use command here
                    while (reader.Read())
                    {
                        Transaction transaction = new Transaction(
                            Convert.ToInt32(reader["TransactionId"]),
                            Convert.ToInt64(reader["AccountNumber"]),
                            Convert.ToDateTime(reader["TransactionDate"]),
                            reader["TransactionType"].ToString(),
                            Convert.ToSingle(reader["Amount"])
                        );
                        transactions.Add(transaction);
                    }
                }
            }
            return transactions;
        }

        private Customer GetCustomer(int customerId)
        {
            Customer customer = null;
            using (SqlConnection conn = DBUtil.getDBConn())

            {
                if (conn != null)
                {
                    string query = "SELECT * FROM Customers WHERE CustomerId = @customerId";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customer = new Customer(
                            Convert.ToInt32(reader["CustomerId"]),
                            reader["Name"].ToString(),
                            reader["Email"].ToString(),
                            reader["Address"].ToString(),
                            reader["Phone"].ToString()
                        );
                    }
                }
            }
            return customer;
        }
    }
}
