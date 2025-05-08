using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Dtos
{
    public class AnimalDto
    {
        public string Species { get; set; }
        public string OriginCountry { get; set; }
        public string Name { get; set; }
        public decimal CostOfKeeping { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
