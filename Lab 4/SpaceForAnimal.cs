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
        private RoomType type;
        private int number;
        private int size;
        private int costForCleaning;
        private List<AccountingUnit> animals;

        public Room(RoomType room, int number, int size, int costForCleaning)
        {
            this.type = room;
            this.number = number;
            this.size = size;
            this.costForCleaning = costForCleaning;
            this.animals = new List<AccountingUnit>();
        }
        public List<AccountingUnit> Animals => animals;
        public void AddAnimal(AccountingUnit unit) => animals.Add(unit);

        public override string ToString()
        {
            string animalDetails = string.Join("\n", animals.Select(a => a.ToString()));
            return $"Space #{number} ({roomType}) Size: {size} m² Cleaning cost: {costForCleaning} Animals:{animalDetails}";
        }

        public string ToShortString()
        {
            int totalAnimalCost = animals.Sum(a => a.cost);
            return $"Space #{number}, Total Animal Maintenance Cost: {totalAnimalCost}";
        }
        public RoomType roomType
        {
            get => roomType;
            set => roomType = value;
        }

        public int Number
        {
            get => number;
            set => number = value >= 0 ? value : throw new ArgumentException("Номер повинен бути невід’ємним.");
        }

        public int Size
        {
            get => size;
            set => size = value > 0 ? value : throw new ArgumentException("Розмір має бути додатнім.");
        }

        public int CleaningCost
        {
            get => costForCleaning;
            set => costForCleaning = value >= 0 ? value : throw new ArgumentException("Вартість прибирання повинна бути невід’ємною.");
        }
    }
    public class AnimalDto
    {
        public string Name { get; set; }
        public string OriginCountry { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class AccountingUnitDto
    {
        public AnimalDto Animal { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int MaintenanceCost { get; set; }
    }

    public class RoomDto
    {
        public RoomType RoomType { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }
        public int CleaningCost { get; set; }
        public List<AccountingUnitDto> Animals { get; set; } = new List<AccountingUnitDto>();
    }
    public static class RoomMapper
    {
        public static RoomDto ToDto(Room room)
        {
            var animalsList = new List<AccountingUnitDto>();
            foreach (var a in room.Animals)
            {
                var animalDto = new AnimalDto
                {
                    Name = a.Animal.Name,
                    OriginCountry = a.Animal.OriginCountry,
                    BirthDate = a.Animal.BirthDate
                };

                var accountingUnitDto = new AccountingUnitDto
                {
                    Animal = animalDto,
                    ArrivalDate = a.ArrivalDate,
                    MaintenanceCost = a.MaintenanceCost
                };

                animalsList.Add(accountingUnitDto);
            }

            var roomDto = new RoomDto
            {
                RoomType = room.roomType,
                Number = room.Number,
                Size = room.Size,
                CleaningCost = room.CleaningCost,
                Animals = animalsList
            };

            return roomDto;
        }

        public static Room FromDto(RoomDto dto)
        {
            var room = new Room(dto.RoomType, dto.Number, dto.Size, dto.CleaningCost);

            foreach (var a in dto.Animals)
            {
                var animal = new Animal(a.Animal.Name, a.Animal.OriginCountry, a.Animal.BirthDate);
                var unit = new AccountingUnit(animal, a.ArrivalDate, a.MaintenanceCost);
                room.AddAnimal(unit);
            }

            return room;
        }
    }
    public static class DataStorage
    {
        private static readonly string FilePath = "rooms.json";

        public static void Save(List<Room> rooms)
        {
            var dtoList = rooms.Select(RoomMapper.ToDto).ToList();
            var json = JsonSerializer.Serialize(dtoList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static List<Room> Load()
        {
            if (!File.Exists(FilePath)) return new List<Room>();

            var json = File.ReadAllText(FilePath);
            var dtoList = JsonSerializer.Deserialize<List<RoomDto>>(json);
            return dtoList?.Select(RoomMapper.FromDto).ToList() ?? new List<Room>();
        }
    }
    public class RoomViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Room> Rooms { get; set; }

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<Room>(DataStorage.Load());
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
            Save();
        }

        public void Save() => DataStorage.Save(Rooms.ToList());

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
