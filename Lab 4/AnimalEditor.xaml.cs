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
    /// Interaction logic for AnimalEditor.xaml
    /// </summary>
    public partial class AnimalEditor : Window
    {
        public Animal Animal { get; set; } // Для збереження введених даних

        public AnimalEditor()
        {
            InitializeComponent();
            Animal = new Animal();
        }

        public AnimalEditor(Animal animal) : this()
        {
            Animal = animal;
            Species.Text = animal.Species;
            Country.Text = animal.OriginCountry;
            Name.Text = animal.Name;
            CostOfKeeping.Text = animal.CostOfKeeping.ToString();
            EntryDate.SelectedDate = animal.EntryDate;
            BirthDate.SelectedDate = animal.BirthDate;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Animal.Species = Species.Text;
            Animal.Country = Country.Text;
            Animal.Name = Name.Text;
            Animal.CostOfKeeping = decimal.Parse(CostOfKeeping.Text);
            Animal.EntryDate = EntryDate.SelectedDate.Value;
            Animal.BirthDate = BirthDate.SelectedDate.Value;

            DialogResult = true; // Повертаємо дані у основне вікно
            Close();
        }
    }

}
