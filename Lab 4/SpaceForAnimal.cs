using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public enum SpaceType
    {
        Cage,
        Enclosure,
        Aquarium,
        Terrarium
    }
    class SpaceForAnimal
    {
        private SpaceType spaceType;
        private int number;
        private int size;
        private int costForCleaning;
        private List<AccountingUnit> animals;

        public SpaceForAnimal(SpaceType spaceType, int number, int size, int costForCleaning)
        {
            this.spaceType = spaceType;
            this.number = number;
            this.size = size;
            this.costForCleaning = costForCleaning;
            this.animals = new List<AccountingUnit>();
        }
        public void AddAnimal(AccountingUnit unit)
        {
            animals.Add(unit);
        }

        public override string ToString()
        {
            string animalDetails = string.Join("\n", animals.Select(a => a.ToString()));
            return $"Space #{number} ({spaceType}) Size: {size} m² Cleaning cost: {costForCleaning} Animals:{animalDetails}";
        }

        public string ToShortString()
        {
            int totalAnimalCost = animals.Sum(a => a.cost);
            return $"Space #{number}, Total Animal Maintenance Cost: {totalAnimalCost}";
        }
        public int Number => number;
        public int Size => size;
        public int CleaningCost => costForCleaning;
        public List<AccountingUnit> Animals => animals;
    }
}
