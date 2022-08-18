using System;
using System.Collections.Generic;

namespace FootballTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teamsDict = new Dictionary<string, Team>();
            string input = Console.ReadLine();
            //Team;Arsenal
            //Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
            //Add; Arsenal; Aaron_Ramsey; 95; 82; 82; 89; 68
            //Remove; Arsenal; Aaron_Ramsey
            //Rating; Arsenal
            //END

            while (input != "END")
            {
                string[] inputInfo = input.Split(';');

                try
                {
                    if (inputInfo[0] == "Team")
                    { // Team;{TeamName}" - add a new Team;

                        string teamName = inputInfo[1];
                        Team team = new Team(teamName);

                        teamsDict.Add(teamName, team);
                    }
                    else if (inputInfo[0] == "Add")
                    { // •	"Add;{TeamName};{PlayerName};{Endurance};{Sprint};{Dribble};{Passing};{Shooting}"
                        string teamName = inputInfo[1];
                        if (!teamsDict.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }
                        string playerName = inputInfo[2];
                        int endurance = int.Parse(inputInfo[3]);
                        int sprint = int.Parse(inputInfo[4]);
                        int dribble = int.Parse(inputInfo[5]);
                        int passing = int.Parse(inputInfo[6]);
                        int shooting = int.Parse(inputInfo[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teamsDict[teamName].AddPlayer(player);
                    }
                    else if (inputInfo[0] == "Remove")
                    { //•	"Remove;{TeamName};{PlayerName}" - remove the Player from the Team;
                        string teamNameRemove = inputInfo[1];

                        if (!teamsDict.ContainsKey(teamNameRemove))
                        {
                            Console.WriteLine($"Team {teamNameRemove} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }
                        string playerNameRemove = inputInfo[2];
                        bool isRemoved = teamsDict[teamNameRemove].RemovePlayer(playerNameRemove);
                        if (!isRemoved)
                        {
                            Console.WriteLine($"Player {playerNameRemove} is not in {teamNameRemove} team.");
                        }

                    }
                    else if (inputInfo[0] == "Rating")
                    { // •	"Rating;{TeamName}" - print the Team rating, rounded to an integer.
                        string teamName = inputInfo[1];

                        if (!teamsDict.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teamsDict[teamName].Stats}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
