using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class AccountingUnit
    {
        private Animal animal;
        private DateTime entryDate;
        public int cost;
        public AccountingUnit(Animal animal, DateTime entryDate, int cost)
        {
            this.animal = animal;
            this.entryDate = entryDate;
            this.cost = cost;
        }
        public Animal GetAnimal() => animal;
        public DateTime GetEntryDate() => entryDate;
        public int GetCost() => cost;
        public void SetCost(int newCost) => this.cost = newCost;
    }
}
