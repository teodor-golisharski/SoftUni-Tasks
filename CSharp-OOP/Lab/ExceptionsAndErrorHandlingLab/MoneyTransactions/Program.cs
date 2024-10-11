using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    public class Program
    {
        static void InvalidCommand()
        {
            throw new Exception("Invalid command!");
        }
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            string[] command = Console.ReadLine().Split(',');

            foreach (var item in command)
            {
                string[] cmdArgs = item.Split('-');

                int accountNumber = int.Parse(cmdArgs[0]);
                double balance = double.Parse(cmdArgs[1]);

                BankAccount bankAcc = new BankAccount(accountNumber, balance);

                bank.BankData.Add(accountNumber, bankAcc);
            }

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string[] tokens = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string transaction = tokens[0];
                int accNum = int.Parse(tokens[1]);
                double balance = double.Parse(tokens[2]);

                switch (transaction)
                {
                    case "Deposit":
                        try
                        {
                            bank.CheckAccountNumber(accNum);
                            
                            bank.BankData[accNum].Deposit(balance);
                            
                            Console.WriteLine($"Account {accNum} has new balance: {bank.BankData[accNum].Balance:f2}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            
                        }
                        break;

                    case "Withdraw":
                        try
                        {
                            bank.CheckAccountNumber(accNum);

                            bank.BankData[accNum].Withdraw(balance);

                            Console.WriteLine($"Account {accNum} has new balance: {bank.BankData[accNum].Balance:f2}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            
                        }
                        break;

                    default:
                        try
                        {
                            InvalidCommand();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            
                        }
                        break;

                }
                Console.WriteLine("Enter another command");
                cmd = Console.ReadLine();
            }
        }
    }
    public class BankAccount
    {
        public BankAccount(int accountNumber, double balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        public void Deposit(double sum)
        {
            Balance += sum;
        }

        public void Withdraw(double sum)
        {
            if (Balance < sum)
            {
                throw new Exception("Insufficient balance!");
            }
            Balance -= sum;
        }

        
    }

    public class Bank
    {
        public Bank()
        {
            this.BankData = new Dictionary<int, BankAccount>();
        }
        public Dictionary<int, BankAccount> BankData { get; set; }

        public void CheckAccountNumber(int number)
        {
            if (!BankData.ContainsKey(number))
            {
                throw new Exception("Invalid account!");
            }
        }
    }
}
