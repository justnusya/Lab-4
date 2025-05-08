using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    public partial class MainWindow : Window
    {
        private readonly string dataFilePath = "rooms.json";
        private readonly ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        public MainWindow()
        {
            InitializeComponent();
            SpacesBox.ItemsSource = rooms;
            LoadDataFromJson(dataFilePath);
        }

        private void AddSpace_Click(object sender, RoutedEventArgs e)
        {
            var editorWindow = new RoomEditorWindow();
            if (editorWindow.ShowDialog() == true)
            {
                rooms.Add(editorWindow.Room);
            }
        }
        private void EditSpace_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem is Room selected)
            {
                var window = new RoomEditorWindow(selected);
                if (window.ShowDialog() == true)
                {
                    int index = rooms.IndexOf(selected);
                    rooms[index] = window.Room;
                }
            }
        }
        private void DeleteSpace_Click(object sender, RoutedEventArgs e)
        {
            if (SpacesBox.SelectedItem is Room selected)
            {
                rooms.Remove(selected);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveDataToJson(dataFilePath);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void LoadDataFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var options = new JsonSerializerOptions
                    {
                        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                    };

                    var json = File.ReadAllText(filePath);
                    var loadedRooms = JsonSerializer.Deserialize<ObservableCollection<Room>>(json, options);
                    if (loadedRooms != null)
                    {
                        rooms.Clear();
                        foreach (var room in loadedRooms)
                        {
                            rooms.Add(room);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні: {ex.Message}");
            }
        }
        private void SaveDataToJson(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                };

                var json = JsonSerializer.Serialize(rooms, options);
                File.WriteAllText(filePath, json);
                MessageBox.Show("Дані успішно збережені!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні: {ex.Message}");
            }
        }
    }
}
