using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Room> rooms;
        public MainWindow()
        {
            InitializeComponent();
            rooms = new ObservableCollection<Room>();
            SpacesBox.ItemsSource = rooms;
        }

        private void AddSpace_Click(object sender, RoutedEventArgs e)
        {
            var editorWindow = new RoomEditorWindow();
            editorWindow.ShowDialog();

            // Перевіряємо, чи користувач зберіг зміни
            if (editorWindow.DialogResult == true)
            {
                rooms.Add(editorWindow.Room);
            }
        }
        private void EditSpace_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem == null) return; // Якщо не вибрано жодного приміщення

            var selectedRoom = (Room)SpacesBox.SelectedItem;
            var editorWindow = new RoomEditorWindow(selectedRoom);
            editorWindow.ShowDialog();

            if (editorWindow.DialogResult == true)
            {
                var index = rooms.IndexOf(selectedRoom);
                rooms[index] = editorWindow.Room; // Оновлюємо дані приміщення
            }
        }
        private void DeleteSpace_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem == null) return;

            rooms.Remove((Room)SpacesBox.SelectedItem);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // треба зробити збереження даних у файл
            MessageBox.Show("Збережено!");
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
