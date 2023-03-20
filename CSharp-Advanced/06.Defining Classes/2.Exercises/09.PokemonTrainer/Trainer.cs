using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();  // ako go ostavim "Pokemons = pokemons" -> null refference exception error code! zashtoto trqbva da inicializirame kolekciqta oshte tuk kato nov spisuk.
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
