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
    public partial class RoomEditorWindow : Window
    {
        public Room Room { get; set; } = new Room();
        private readonly List<Animal> animals = new List<Animal>();
        public RoomEditorWindow()
        {
            InitializeComponent();
            ComboBoxType.ItemsSource = Enum.GetValues(typeof(RoomType));
            SpacesBox.ItemsSource = animals;
        }

        public RoomEditorWindow(Room room) : this()
        {
            Room = room;
            ComboBoxType.SelectedItem = room.Type;
            TextBoxNumber.Text = room.Number;
            TextBoxSize.Text = room.Size.ToString();
            TextBoxCleaningCost.Text = room.CleaningCost.ToString();
            animals.AddRange(room.Animals);
            SpacesBox.Items.Refresh();
        }

        private void AddAccUnit_Click(object sender, RoutedEventArgs e)
        {
            var editor = new AnimalEditor();
            if (editor.ShowDialog() == true)
            {
                animals.Add(editor.Animal);
                SpacesBox.Items.Refresh();
            }
        }

        private void EditAccUnit_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem is Animal selected)
            {
                var editor = new AnimalEditor(selected);
                if (editor.ShowDialog() == true)
                {
                    int index = animals.IndexOf(selected);
                    animals[index] = editor.Animal;
                    SpacesBox.Items.Refresh();
                }
            }
        }

        private void DeleteAccUnit_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem is Animal selected)
            {
                animals.Remove(selected);
                SpacesBox.Items.Refresh();
            }
        }

        private void SaveAccUnit_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxType.SelectedItem is RoomType selectedType)
            {
                Room.Type = selectedType;
            }
            Room.Number = TextBoxNumber.Text;
            Room.Size = double.TryParse(TextBoxSize.Text, out var size) ? size : 0;
            Room.CleaningCost = double.TryParse(TextBoxCleaningCost.Text, out var cost) ? cost : 0;
            Room.Animals = new List<Animal>(animals);

            DialogResult = true;
            Close();
        }
        private void TextBox_Numeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string text)
        {
            return text.All(char.IsDigit);
        }
        private void TextBox_Numeric_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextNumeric(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
