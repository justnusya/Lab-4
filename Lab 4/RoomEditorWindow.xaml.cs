using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for RoomEditorWindow.xaml
    /// </summary>
    public partial class RoomEditorWindow : Window
    {
        public Room Room { get; set; } // Об'єкт для редагування

        public RoomEditorWindow()
        {
            InitializeComponent();
            //Room = new Room(); // Створюємо нове приміщення
        }

        public RoomEditorWindow(Room room) : this()
        {
            Room = room;
            // Заповнюємо поля редагування
            ComboBoxType.SelectedItem = room.roomType;
            TextBoxNumber.Text = room.Number.ToString();
            TextBoxSize.Text = room.Size.ToString();
            TextBoxCleaningCost.Text = room.CleaningCost.ToString();
        }

        private void AddAccUnit_Click(object sender, RoutedEventArgs e)
        {
            var animalEditor = new AnimalEditor();
            animalEditor.ShowDialog();

            if (animalEditor.DialogResult == true)
            {
                Room.AddAnimal(AccountingUnit(animalEditor.Animal)); // Додаємо тварину до кімнати
            }
        }

        private void EditAccUnit_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem == null) return; // Якщо не вибрано тварину для редагування

            var selectedAnimal = (Animal)SpacesBox.SelectedItem;
            var animalEditor = new AnimalEditor(selectedAnimal);
            animalEditor.ShowDialog();

            if (animalEditor.DialogResult == true)
            {
                //Room.UpdateAnimal(selectedAnimal); // Оновлюємо інформацію про тварину
            }
        }

        private void DeleteAccUnit_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem == null) return;

            //Room.RemoveAnimal((Animal)SpacesBox.SelectedItem); // Видаляємо тварину з кімнати
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Оновлюємо дані приміщення
            Room.roomType = (RoomType)ComboBoxType.SelectedItem;
            Room.Number = int.Parse(TextBoxNumber.Text);
            Room.Size = int.Parse(TextBoxSize.Text);
            Room.CleaningCost = int.Parse(TextBoxCleaningCost.Text);

            DialogResult = true; // Повертаємо зміни в основне вікно
            Close();
        }
    }
}
