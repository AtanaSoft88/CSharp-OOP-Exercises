using System;
using System.Linq;

namespace _06.MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            //1473653 - 97.34,44643345 - 2347.90
            //Withdraw 1473653 150.50
            //Deposit 44643345 200
            //Block 1473653 30
            //Deposit 1 30
            //End

            string[] inputAccountInfo = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);
            string[] cmdArgs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (cmdArgs[0] != "End")
            {
                try
                {
                    if (IsValidCommand(cmdArgs))
                    {
                        if (IsValidAccount(cmdArgs, inputAccountInfo))
                        {
                            if (cmdArgs[0] == "Withdraw")
                            {                           
                                
                                foreach (string pair in inputAccountInfo)
                                {
                                    int bankAaccountName = int.Parse(pair.Split('-',StringSplitOptions.RemoveEmptyEntries)[0]);
                                    int depositAccountName = int.Parse(cmdArgs[1]);
                                    if (bankAaccountName == depositAccountName)
                                    {
                                        double depositSum = double.Parse(pair.Split('-',StringSplitOptions.RemoveEmptyEntries)[1]);
                                        double depositcmd = double.Parse(cmdArgs[2]);
                                        if (depositSum >= depositcmd)
                                        {
                                           double result = depositSum - depositcmd;
                                            Console.WriteLine($"Account {bankAaccountName} has new balance: {result:f2}");
                                        }
                                        else
                                        {
                                            throw new ArgumentException("Insufficient balance!");
                                        }
                                        break;

                                    }

                                }

                            }
                            else //"Deposit"
                            {
                                foreach (string pair in inputAccountInfo)
                                {
                                    int bankAaccountName = int.Parse(pair.Split('-',StringSplitOptions.RemoveEmptyEntries)[0]);
                                    int depositAccountName = int.Parse(cmdArgs[1]);
                                    if (bankAaccountName == depositAccountName)
                                    {
                                        double depositSum = double.Parse(pair.Split('-',StringSplitOptions.RemoveEmptyEntries)[1]);
                                        double depositcmd = double.Parse(cmdArgs[2]);
                                        double result = depositSum + depositcmd;
                                        Console.WriteLine($"Account {bankAaccountName} has new balance: {result:f2}");
                                        break;
                                    }

                                }

                            }

                        }
                        else
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter another command");
                cmdArgs = Console.ReadLine().Split();
            }            

        }

        private static bool IsValidAccount(string[] cmdArgs, string[] inputAccountInfo)
        {    // 1-45.67 , 2-3256.09 , 3-97.34
            foreach (string pair in inputAccountInfo)
            {
                int bankAaccountName = int.Parse(pair.Split('-',StringSplitOptions.RemoveEmptyEntries)[0]);
                int depositAccountName = int.Parse(cmdArgs[1]);
                if (bankAaccountName == depositAccountName)
                {
                    return true;
                }

            }
            return false;
        }

        private static bool IsValidCommand(string[] cmdArgs)
        {
            if (cmdArgs[0] == "Withdraw" || cmdArgs[0] == "Deposit")
            {
                return true;
            }
            return false;
        }
    }
}
