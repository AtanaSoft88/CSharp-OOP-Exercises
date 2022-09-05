using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach (var item in input)
            {
                string[] currItem = item.Split("-");
                int account = int.Parse(currItem[0]);
                double balance = double.Parse(currItem[1]);
                accounts.Add(account, balance);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] currCommand = command.Split();
                    if (currCommand[0] == "Deposit")
                    {
                        if (!accounts.ContainsKey(int.Parse(currCommand[1])))
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        else
                        {
                            accounts[int.Parse(currCommand[1])] += double.Parse(currCommand[2]);
                            Console.WriteLine($"Account {currCommand[1]} has new balance: {accounts[int.Parse(currCommand[1])]:F2}");
                        }
                    }
                    else if (currCommand[0] == "Withdraw")
                    {
                        if (!accounts.ContainsKey(int.Parse(currCommand[1])))
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        else if (accounts[int.Parse(currCommand[1])] < double.Parse(currCommand[2]))
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }
                        else
                        {
                            accounts[int.Parse(currCommand[1])] -= double.Parse(currCommand[2]);
                            Console.WriteLine($"Account {currCommand[1]} has new balance: {accounts[int.Parse(currCommand[1])]:F2}");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter another command");
                command = Console.ReadLine();
            }
        }
    }
}