namespace Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ComputerComponent> parts = new List<ComputerComponent>();
            ComputerComponent component = null;
            string[] input = { "LGA1200, -200", "ROG-16GB-DDR5, -150", "ROG-8GB-DDR4, 135", "LGA1200, 560", "LGA1700, 770", "LGA1700, -20" };
            for (int i = 0; i < input.Length; i++)
            {
                string ramName = input[i].Split(", ")[0].Contains("DDR") ? input[i].Split(", ")[0] : null;
                if (ramName != null)
                {
                    component = new Ram(ramName, decimal.Parse(input[i].Split(", ")[1]));
                }
                else 
                {
                    string cpuName = input[i].Split(", ")[0].Contains("LGA") ? input[i].Split(", ")[0] : null;
                    component = new CPU(cpuName, decimal.Parse(input[i].Split(", ")[1]));
                }
                component.AddVAT();
                component.PartsOrder(1);
                component.RepairExpenses();
                component.UnexpectedExpenses();
                parts.Add(component);
            }
            var resultTotalPrice = component.SumPrice(parts);
            Console.WriteLine(resultTotalPrice.ToString("f2"));
        }
    }
}