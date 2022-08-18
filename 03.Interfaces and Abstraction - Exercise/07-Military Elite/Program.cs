using MilitaryElite.Implementations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,ISoldier> soldiersCollection = new Dictionary<int,ISoldier>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();
                string action = inputInfo[0];
                int id = int.Parse(inputInfo[1]);
                string firstName = inputInfo[2];
                string lastName = inputInfo[3];

                if (action == "Private")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    IPrivate @private = new Private(id,firstName,lastName,salary);
                    soldiersCollection.Add(id,@private);
                     
                }
                else if (action == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < inputInfo.Length; i++)
                    {
                        int inputId = int.Parse(inputInfo[i]);
                        IPrivate @private = soldiersCollection[inputId] as IPrivate;
                        lieutenantGeneral.Privates.Add(@private);
                    }
                    soldiersCollection.Add(id,lieutenantGeneral);
                }
                else if (action == "Engineer")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpAsString = inputInfo[5];
                    bool isValidEnum = Enum.TryParse(corpAsString,out Corps result); // try to parse that string and if succeeded , record it in the out "result" , if you cant parse it , return "isValid = false"

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < inputInfo.Length; i+=2)
                    {
                        string partName = inputInfo[i]; 
                        int hours = int.Parse(inputInfo[i+1]);
                        IRepair repair = new Repair();
                        repair.PartName = partName;
                        repair.HoursWorked = hours;

                        engineer.Repairs.Add(repair);
                    }
                    soldiersCollection.Add(id, engineer);
                }
                else if (action == "Commando")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpAsString = inputInfo[5];
                    bool isValidEnum = Enum.TryParse(corpAsString, out Corps result); 

                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    ICommando commando = new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < inputInfo.Length; i += 2)
                    {
                        string missionCode = inputInfo[i];
                        string missionStateAsString = inputInfo[i + 1];
                        bool isValidMission = Enum.TryParse(missionStateAsString, out Status missionResult);
                        if (!isValidMission)
                        {                            
                            continue;
                        }

                        IMission mission = new Mission(missionCode,missionResult);

                        commando.Missions.Add(mission);
                    }
                    soldiersCollection.Add(id,commando);
                }
                else if (action == "Spy")
                {
                    int codeNumber = int.Parse(inputInfo[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersCollection.Add(id,spy);
                }
                input = Console.ReadLine();
            }
            foreach (var item in soldiersCollection)    
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
