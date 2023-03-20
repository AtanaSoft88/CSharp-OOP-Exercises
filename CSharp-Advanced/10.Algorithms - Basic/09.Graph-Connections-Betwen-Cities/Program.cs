namespace Graph_Connections_Betwen_Cities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pairs of string - Cities and outputs connections between the Cities
            // input:
            /* 
             Varna Sofia
             Varna Burgas
             Burgas Turnovo
             Turnovo Sofia
             Burgas Turnovo
              */
            string inputCities = Console.ReadLine();
            var graph = new Dictionary<string, List<string>>();

            while (inputCities != string.Empty)
            {
                string[] connection = inputCities.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string firstCity = connection[0];
                string secondCity = connection[1];

                if (!graph.ContainsKey(firstCity))
                {
                    graph[firstCity] = new List<string>();
                }

                graph[firstCity].Add(secondCity);

                if (firstCity != secondCity)
                {
                    if (!graph.ContainsKey(secondCity))
                    {
                        graph[secondCity] = new List<string>();
                    }
                    graph[secondCity].Add(firstCity);

                }

                inputCities = Console.ReadLine();
            }

            foreach (var city in graph)
            {
                Console.Write(city.Key + " -> ");
                foreach (var neighbour in city.Value)
                {
                    Console.Write(neighbour + " ");
                }
                Console.WriteLine();
            }
        }
    }
}