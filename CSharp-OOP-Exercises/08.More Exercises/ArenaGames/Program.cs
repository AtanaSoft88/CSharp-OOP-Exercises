namespace ArenaGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFighter fighterMage = new Mage();
            IFighter fighterArcher = new Archer();
            IFighter fighterSwordsman = new Swordsman();
            var arena = new Arena();

            arena.AddFightersToArena(fighterMage);
            arena.AddFightersToArena(fighterArcher);
            arena.AddFightersToArena(fighterSwordsman);

           var fightResult = arena.Fight(arena.ArenaFighters);
            Console.WriteLine(fightResult);
        }
    }
}