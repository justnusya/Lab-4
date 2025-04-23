using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Animal
    {
        private string species;
        private string origin_country;
        private string name;
        private DateTime birthDate;
        public Animal(string species,string origin_country, string name, DateTime birthDate)
        {
            this.species = species;
            this.origin_country = origin_country;
            this.name = name;
            this.birthDate = birthDate;
        }
        public string Name => name;
        public string Origin_country => origin_country;
        public string Species => species;
        public DateTime BirthDate => birthDate;
    }
}
