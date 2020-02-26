using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCIProject1
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            ComboboxClass.ItemsSource = Classes.Class;
            
        }
        public string image;

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                DateTime date = DatePickerDate.SelectedDate.Value;
                MainWindow.Decks.Add(new Deck(TextBoxName.Text, ComboboxClass.SelectedValue.ToString(), TextBoxAbouth.Text, Int32.Parse(TextBoxMana.Text), date.ToString("dd/MM/yyyy"), image));
                this.Close();
            }
            else
            {
                MessageBox.Show("Some fields cant be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddPicture_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All Files|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                img.Source = new ImageSourceConverter().ConvertFromString(filename) as ImageSource;
                image = filename;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private bool Validate()
        {
            bool result = true;

            if (TextBoxName.Text.Trim().Equals(""))
            {
                result = false;
                labelNameErr.Content = "Field can't be empty!";
                TextBoxName.BorderBrush = Brushes.Red;
            }
            else
            {
                labelNameErr.Content = "";
                TextBoxName.BorderBrush = Brushes.Gray;
            }

            if (ComboboxClass.SelectedItem == null) 
            {

                result = false;
                labelClassErr.Content = "You must choose an Class!";
                ComboboxClass.BorderBrush = Brushes.Red;

            }
            else
            {
                labelClassErr.Content = "";
                ComboboxClass.BorderBrush = Brushes.Gray;
            }

            if (DatePickerDate.SelectedDate==null)
            {
                result = false;
                labelDateErr.Content = "Field can't be empty!";
                DatePickerDate.BorderBrush = Brushes.Red;
            }
            else if(DatePickerDate.SelectedDate > DateTime.Now)
            {
                result = false;
                labelDateErr.Content = "Data can't be in the future!";
                DatePickerDate.BorderBrush = Brushes.Red;
            }
            else
            {
                labelDateErr.Content = "";
                DatePickerDate.BorderBrush = Brushes.Gray;
            }
            if(image != "" && image != null)
            {
                labelPicErr.Content = "";
                ButtonAddPicture.BorderBrush = Brushes.Gray;
            }
            else
            {
                result = false;
                labelPicErr.Content = "Picture can't be empty";
                ButtonAddPicture.BorderBrush = Brushes.Red;
            }
            if (TextBoxMana.Text == "" || TextBoxMana == null)
            {
                result = false;
                labelManaErr.Content = "Mana can't be empty!";
                TextBoxMana.BorderBrush = Brushes.Red;
            }
            else if (Int32.Parse(TextBoxMana.Text) < 0)
            {
                result = false;
                labelManaErr.Content = "Mana can't be negative value!";
                TextBoxMana.BorderBrush = Brushes.Red;
            }
            else
            {
                labelManaErr.Content = "";
                TextBoxMana.BorderBrush = Brushes.Gray;
            }

            return result;
        }

        private void ComboboxClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

   
}
