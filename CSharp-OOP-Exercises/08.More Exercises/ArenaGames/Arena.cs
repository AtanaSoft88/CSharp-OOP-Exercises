using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGames
{
    public class Arena
    {
        private Queue<IFighter> arenaFighters = new Queue<IFighter>();

        public void AddFightersToArena(IFighter fighter)
        {
            arenaFighters.Enqueue(fighter);
        }
        public Queue<IFighter> ArenaFighters => arenaFighters;
        public string Fight(Queue<IFighter> fighters)
        {
            var sb = new StringBuilder();
            while (fighters.Count() > 0)
            {
                if (fighters.Count() >= 2)
                {
                    var firstFighter = fighters.Dequeue();
                    var secondFighter = fighters.Dequeue();
                    sb.AppendLine(firstFighter.GetType().Name + $" HP: {firstFighter.Hp} / Damage: {firstFighter.Damage} / Defence: {firstFighter.Defence} ");
                    sb.AppendLine("- - = VS = - -");
                    sb.AppendLine(secondFighter.GetType().Name + $" HP: {secondFighter.Hp} / Damage: {secondFighter.Damage} / Defence: {secondFighter.Defence} ");
                    sb.AppendLine(new string('#', 65));
                    while (firstFighter.Hp > 0 && secondFighter.Hp > 0)
                    {
                        int chanceForSpecialAttack = new Random().Next(1,100);
                        if (chanceForSpecialAttack % 5 == 0)
                        {
                            sb.AppendLine($"Lucky Number: {chanceForSpecialAttack}");
                            sb.AppendLine(firstFighter.SpecialAttack(secondFighter));
                        }
                        else if (chanceForSpecialAttack % 3 == 0) 
                        {
                            sb.AppendLine($"Lucky Number: {chanceForSpecialAttack}");
                            sb.AppendLine(secondFighter.SpecialAttack(firstFighter));
                        }
                        sb.AppendLine(firstFighter.Attack(secondFighter));
                        sb.AppendLine(secondFighter.Attack(firstFighter));
                        
                        
                        if (firstFighter.Hp <= 0)
                        {
                            sb.AppendLine($"{firstFighter.GetType().Name} has been slain.");
                            sb.AppendLine($"{secondFighter.GetType().Name} won the battle and remained with {secondFighter.Hp} hp.");
                            break;
                        }
                        else if (secondFighter.Hp <= 0)
                        {
                            sb.AppendLine($"{secondFighter.GetType().Name} has been slain.");
                            sb.AppendLine($"{firstFighter.GetType().Name} won the battle and remained with {firstFighter.Hp} hp.");
                            break;

                        }
                    }
                    return sb.ToString();

                }
                else
                {
                    sb.AppendLine("There must be more than one player to make a battle!");
                    break;

                }
            }
            return sb.ToString();
        }
    }
}
