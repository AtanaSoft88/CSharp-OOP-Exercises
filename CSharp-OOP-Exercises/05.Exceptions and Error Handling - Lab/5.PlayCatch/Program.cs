using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersInput = Console.ReadLine().Split().Select(int.Parse).ToList(); //1 2 3 4 5
            int exceptionsCount = 0;

            while (exceptionsCount != 3)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                Validator validator = new Validator(false, false, false);    // class initializing !            
                try
                {
                    validator.GetDataValidated(cmdArgs, numbersInput);
                    if (cmdArgs[0] == "Replace")
                    {
                        if (validator.IsInteger)
                        {
                            int index = int.Parse(cmdArgs[1]);
                            int element = int.Parse(cmdArgs[2]);
                            if (validator.IsInRange)
                            {
                                numbersInput.RemoveAt(index);
                                numbersInput.Insert(index, element);
                            }
                            else
                            {
                                throw new ArgumentException("The index does not exist!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("The variable is not in the correct format!");
                        }
                    }
                    else if (cmdArgs[0] == "Print")
                    {
                        if (validator.IsInteger)
                        {
                            int startIndex = int.Parse(cmdArgs[1]);
                            int endIndex = int.Parse(cmdArgs[2]);
                            string result = string.Empty;
                            StringBuilder sb = new StringBuilder();
                            if (validator.IsInRange)
                            {
                                for (int i = startIndex; i <= endIndex; i++)
                                {
                                    sb.Append(numbersInput[i] + ", ");
                                }
                                result = sb.ToString().TrimEnd(new char[] { ' ', ',' });
                                Console.WriteLine(result);
                            }
                            else
                            {
                                throw new ArgumentException("The index does not exist!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("The variable is not in the correct format!");
                        }
                    }
                    else //  Show
                    {
                        if (validator.IsInteger)
                        {
                            int index = int.Parse(cmdArgs[1]);
                            if (validator.IsInRange)
                            {
                                Console.WriteLine(numbersInput[index]);
                            }
                            else
                            {
                                throw new ArgumentException("The index does not exist!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("The variable is not in the correct format!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    exceptionsCount++;
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(", ", numbersInput));


        }

        public class Validator
        {
            public Validator(bool isInteger, bool isInRange, bool inRangeToPrint)
            {
                IsInteger = isInteger;
                IsInRange = isInRange;
                InRangeToPrint = inRangeToPrint;
            }

            public bool IsInteger { get; private set; }
            public bool IsInRange { get; private set; }
            public bool InRangeToPrint { get; private set; }


            public void GetDataValidated(string[] args, List<int> input)
            {
                if (args.Length == 3)
                {
                    if (args[0] == "Replace")
                    {
                        bool isValidIndex = int.TryParse(args[1], out int recIndex); // if is integer
                        bool isValidElement = int.TryParse(args[2], out int recElement); // if is integer
                        if (isValidIndex && isValidElement)
                        {
                            IsInteger = true;
                            if (recIndex >= 0 && recIndex < input.Count)
                            {
                                IsInRange = true;
                            }
                        }
                    }
                    else  // Print
                    {
                        bool isValidStartIndex = int.TryParse(args[1], out int recIndexStart); // if is integer
                        bool isValidEndIndex = int.TryParse(args[2], out int recIndexEnd); // if is integer
                        if (isValidStartIndex && isValidEndIndex)
                        {
                            IsInteger = true;
                            if (recIndexStart >= 0 && recIndexEnd < input.Count)
                            {
                                IsInRange = true;
                            }
                        }
                    }
                }
                else // show
                {
                    bool isValidIndex = int.TryParse(args[1], out int recIndex); // if is integer

                    if (isValidIndex)
                    {
                        IsInteger = true;
                        if (recIndex >= 0 && recIndex < input.Count)
                        {
                            IsInRange = true;
                        }
                    }
                }
            }
        }
    }
}
