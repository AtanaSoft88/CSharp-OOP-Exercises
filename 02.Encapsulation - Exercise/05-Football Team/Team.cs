using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeam
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
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
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            
           return players.Remove(player);
        }
        public int Stats => players.Any() ? (int)Math.Round(this.players.Average(x => x.Stats)) : 0;  
        // get all players average points rounded up to integer if there is something inside collection , else return 0;

    }
}
