using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab_4
{
    public enum RoomType
    {
        Cage,
        Enclosure,
        Aquarium,
        Terrarium
    }
    public class Room
    {
        public RoomType Type { get; set; }
        public string Number { get; set; }
        public double Size { get; set; }
        public double CleaningCost { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public override string ToString()
        {
            return $"{Type} №{Number}, {Size} м², прибирання: {CleaningCost} грн";
        }
    }
    public class Animal
    {
        public string Species { get; set; }
        public string OriginCountry { get; set; }
        public string Name { get; set; }
        public decimal CostOfKeeping { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString() =>
            $"Animal: {Name}, {Species}, {OriginCountry}, Birthday: {BirthDate.ToShortDateString()}";
    }
    public class AccountingUnit
    {
        public Animal Animal { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int MaintenanceCost { get; set; }

        public override string ToString() =>
            $"[{ArrivalDate.ToShortDateString()}] {Animal.Name} - {MaintenanceCost} грн";
    }
}
