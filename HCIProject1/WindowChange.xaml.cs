using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for WindowChange.xaml
    /// </summary>
    public partial class WindowChange : Window
    {
        private string immage;
        public WindowChange()
        {
            InitializeComponent();
            ComboboxClass.ItemsSource = Classes.Class;

            TextBoxName.Text = MainWindow.d.DeckName;
            ComboboxClass.SelectedItem = MainWindow.d.DeckCLass;
            //DateTime d = new DateTime();
            TextBoxMana.Text = MainWindow.d.AvgMana.ToString();


            string myDate = MainWindow.d.DateTime;
            DatePickerDate.SelectedDate = DateTime.ParseExact(MainWindow.d.DateTime, "dd/MM/yyyy",CultureInfo.InvariantCulture); 
            //DatePickerDate.SelectedDate = Convert.ToDateTime(dt1);


            TextBoxAbouth.Text = MainWindow.d.Aboutn;
            img.Source = MainWindow.d.Img;


            //MainWindow.d.DateTime
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                MainWindow.d.DeckName = TextBoxName.Text;
                MainWindow.d.DeckCLass = ComboboxClass.SelectedItem.ToString();
                MainWindow.d.AvgMana = Int32.Parse(TextBoxMana.Text);
                MainWindow.d.DateTime = DatePickerDate.SelectedDate.Value.ToString("dd/MM/yyyy");
                MainWindow.d.Aboutn = TextBoxAbouth.Text;
                if (immage != "" && immage != null)
                {
                    MainWindow.d.Img = new ImageSourceConverter().ConvertFromString(immage) as BitmapSource;
                }
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
            dlg.Filter = dlg.Filter = "All Files|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                img.Source = new ImageSourceConverter().ConvertFromString(filename) as ImageSource;
                immage = filename;

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

            if (DatePickerDate.SelectedDate == null)
            {
                result = false;
                labelDateErr.Content = "Field can't be empty!";
                DatePickerDate.BorderBrush = Brushes.Red;
            }
            else if (DatePickerDate.SelectedDate > DateTime.Now)
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
            if (TextBoxMana.Text == "" || TextBoxMana == null)
            {
                result = false;
                labelManaErr.Content = "Mana can't be empty!";
                TextBoxMana.BorderBrush = Brushes.Red;
            }
            else if (Int32.Parse(TextBoxMana.Text)<0)
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


    }
}
