using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Animal
    {
        private string species;
        private string origin_country;
        private string name;
        private DateTime birthDate;

        public Animal(string name, string originCountry, DateTime birthDate)
        {
            this.name = name;
            OriginCountry = originCountry;
            this.birthDate = birthDate;
        }

        public Animal(string species,string origin_country, string name, DateTime birthDate)
        {
            this.species = species;
            this.origin_country = origin_country;
            this.name = name;
            this.birthDate = birthDate;
        }
        public string Species
        {
            get;set;
        }
        public string Name
        {
            get => name;
            set => name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Ім'я не може бути порожнім.");
        }

        public string OriginCountry
        {
            get => origin_country;
            set => origin_country = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Країна не може бути порожньою.");
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value <= DateTime.Now ? value : throw new ArgumentException("Дата народження не може бути в майбутньому.");
        }
        public override string ToString() =>
        $"Тварина: {Name}, {OriginCountry}, {BirthDate.ToShortDateString()}";
    }
}
