namespace ArenaGames
{
    public interface IFighter
    {
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        string Attack(IFighter fighter);
        string SpecialAttack(IFighter fighter);
    }
}