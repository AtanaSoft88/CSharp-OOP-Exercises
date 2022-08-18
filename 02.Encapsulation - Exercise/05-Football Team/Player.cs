using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam
{
    public class Player
    {
        private readonly int endurance;
        private readonly int sprint;
        private readonly int dribble;
        private readonly int passing;
        private readonly int shooting;
        private string name;
        private Dictionary<string,int> args;
        // int endurance, int sprint, int dribble, int passing, int shooting  0-100;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;            
            string[] asText = {"Endurance" , "Sprint", "Dribble", "Passing", "Shooting" };
            int[] asInt = { endurance, sprint, dribble, passing, shooting };
            for (int i = 0; i < asText.Length; i++)
            {
                ValidateStat(asInt[i],asText[i]);                
            }
            
            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }        

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public double Stats => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;

        private void ValidateStat(int currentStat, string nameStat)
        {
            if (currentStat < 0 || currentStat > 100)
            {
                throw new ArgumentException($"{nameStat} should be between 0 and 100.");
            }
        } 
    }
}
