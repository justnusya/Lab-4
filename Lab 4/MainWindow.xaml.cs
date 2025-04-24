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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            string species = TextBoxSpecies.Text.Trim();
            string country = TextBoxOriginCountry.Text.Trim();
            string name = TextBoxName.Text.Trim();
            DateTime birthDate = DatePickerBirthDate.SelectedDate.Value;

            if (string.IsNullOrWhiteSpace(species) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please fill in all the fields for species, origin country, and name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DatePickerBirthDate.SelectedDate == null)
            {
                MessageBox.Show("Please select the birth date.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Animal creature = new Animal(species, country, name, birthDate);

            ListBox.Items.Add($"{creature.Name} ({creature.Species}, {creature.Origin_country}) - born {creature.BirthDate.ToShortDateString()}");

            TextBoxSpecies.Clear();
            TextBoxOriginCountry.Clear();
            TextBoxName.Clear();
            DatePickerBirthDate.SelectedDate = null;
        }
    }
}
