using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int minWeight = 1;
        private const int maxWeight = 200;
        private const string invalidDoughMessage = "Invalid type of dough.";
        private string flourType;
        private string bakingTchnique;
        private int weight;

        public Dough(string flourType, string bakingTchnique, int weight)
        {
            FlourType = flourType;
            BakingTchnique = bakingTchnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException(invalidDoughMessage);
                }
                this.flourType = value;
            }
        }
        public string BakingTchnique
        {
            get => bakingTchnique;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "chewy" && valueAsLower != "crispy" && valueAsLower != "homemade")
                {
                    throw new ArgumentException(invalidDoughMessage);
                }
                this.bakingTchnique = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowExceptionNotInRange(minWeight, maxWeight, value, $"Dough weight should be in the range[{ minWeight}..{ maxWeight}].");
                this.weight = value;
            }
        }
        public double GetCalories()
        {
            var flourTypeModifier = GetFlourTypeModifier();
            var bakingTechniqueModifier = GetBakingTehniqueModifier();
            return this.weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        public double GetBakingTehniqueModifier()
        {
            var bakingTehniqueLower = this.BakingTchnique.ToLower();
            if (bakingTehniqueLower == "crispy")
            {
                return 0.9;
            }
            if (bakingTehniqueLower == "chewy")
            {
                return 1.1;
            }
            return 1;
        }

        public double GetFlourTypeModifier()
        {
            var flourTypeLower = this.FlourType.ToLower();
            if (flourTypeLower == "white")
            {
                return 1.5;
            }
            return 1;
        }

    }
}
