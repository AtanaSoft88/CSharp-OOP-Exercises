using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] cmd = input.Split();

                string trainerName = cmd[0];
                string pokemonName = cmd[1];
                string pokemonElement = cmd[2];
                int pokemonHealth = int.Parse(cmd[3]);                              

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(trainerName, newTrainer);
                }
                Pokemon pokemon = new Pokemon(trainerName, pokemonElement, pokemonHealth);
                Trainer trainer = trainers[trainerName];
                trainer.Pokemons.Add(pokemon);


                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input !="End")
            {
                // Fire
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(x=>x.Element == input))
                    {
                        trainer.Value.Badges += 1;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemons.RemoveAll(x=>x.Health <=0);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in trainers.OrderByDescending(x=>x.Value.Badges))
            {
                Console.WriteLine($"{item.Key} {item.Value.Badges} {item.Value.Pokemons.Count()}");
            }
        }
    }
}
