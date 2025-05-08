using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Dtos
{
    public class RoomDto
    {
        public RoomType Type { get; set; }
        public string Number { get; set; }
        public double Size { get; set; }
        public double CleaningCost { get; set; }
        public List<AnimalDto> Animals { get; set; } = new List<AnimalDto>();
    }
    public static class Mapper
    {
        public static RoomDto ToDto(Room room) => new RoomDto
        {
            Type = room.Type,
            Number = room.Number,
            Size = room.Size,
            CleaningCost = room.CleaningCost,
            Animals = room.Animals.Select(ToDto).ToList()
        };

        public static Room FromDto(RoomDto dto) => new Room
        {
            Type = dto.Type,
            Number = dto.Number,
            Size = dto.Size,
            CleaningCost = dto.CleaningCost,
            Animals = dto.Animals.Select(FromDto).ToList()
        };

        public static AnimalDto ToDto(Animal animal) => new AnimalDto
        {
            Species = animal.Species,
            OriginCountry = animal.OriginCountry,
            Name = animal.Name,
            CostOfKeeping = animal.CostOfKeeping,
            EntryDate = animal.EntryDate,
            BirthDate = animal.BirthDate
        };

        public static Animal FromDto(AnimalDto dto) => new Animal
        {
            Species = dto.Species,
            OriginCountry = dto.OriginCountry,
            Name = dto.Name,
            CostOfKeeping = dto.CostOfKeeping,
            EntryDate = dto.EntryDate,
            BirthDate = dto.BirthDate
        };
    }
}
