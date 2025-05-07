using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class AccountingUnit
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
        public Animal Animal
        {
            get => animal;
            set => animal = value ?? throw new ArgumentNullException(nameof(Animal));
        }

        public DateTime ArrivalDate
        {
            get => entryDate;
            set => entryDate = value <= DateTime.Now ? value : throw new ArgumentException("Дата надходження не може бути в майбутньому.");
        }

        public int MaintenanceCost
        {
            get => cost;
            set => cost = value >= 0 ? value : throw new ArgumentException("Вартість утримання повинна бути невід’ємною.");
        }
        public override string ToString() =>
        $"[{ArrivalDate.ToShortDateString()}] {Animal.Name} - {MaintenanceCost} грн";
    }
}
