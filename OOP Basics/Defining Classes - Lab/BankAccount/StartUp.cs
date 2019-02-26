using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var accounts = new Dictionary<int, BankAccount>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var input = command.Split();
                var inputType = input[0];
                switch (inputType)
                {
                    case "Create":
                        Create(input, accounts);
                        break;
                    case "Deposit":
                        Deposit(input, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(input, accounts);
                        break;
                    case "Print":
                        Print(input, accounts);
                        break;
                }
            }

        }

        private static void Print(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            if (accounts.ContainsKey(id))
            {
                var acc = accounts[id];
                Console.WriteLine(acc.ToString());
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            if (accounts.ContainsKey(id))
            {
                var amount = decimal.Parse(input[2]);
                var acc = accounts[id];
                acc.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] input, Dictionary<int, BankAccount> accounts)
        {

            var id = int.Parse(input[1]);
            if (accounts.ContainsKey(id))
            {
                var amount = decimal.Parse(input[2]);
                var acc = accounts[id];
                acc.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }
        }
    }
}
