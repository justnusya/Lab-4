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
    public partial class AnimalEditor : Window
    {
        public Animal Animal { get; set; }

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
            Animal.OriginCountry = Country.Text;
            Animal.Name = Name.Text;
            Animal.CostOfKeeping = decimal.Parse(CostOfKeeping.Text);
            Animal.EntryDate = EntryDate.SelectedDate.Value;
            Animal.BirthDate = BirthDate.SelectedDate.Value;

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
        private void TextBox_Word_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextLetterOrApostrophe(e.Text);
        }
        private void TextBox_Word_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextLetterOrApostrophe(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private static bool IsTextLetterOrApostrophe(string text)
        {
            return text.All(c => char.IsLetter(c) || c == '\'' || c == ' ');
        }
    }
}
