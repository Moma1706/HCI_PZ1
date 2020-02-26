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

namespace HCIProject1
{
    /// <summary>
    /// Interaction logic for WindowOpen.xaml
    /// </summary>
    public partial class WindowOpen : Window
    {
        public WindowOpen()
        {
            InitializeComponent();

            LabelDeckName1.Content = MainWindow.Decks[MainWindow.indeks].DeckName;
            LabelDeckClas1.Content = MainWindow.Decks[MainWindow.indeks].DeckCLass;
            LabelAverageMana1.Content = MainWindow.Decks[MainWindow.indeks].AvgMana;
            LabelDate1.Content = MainWindow.Decks[MainWindow.indeks].DateTime;
            LabelAbouth1.Content = MainWindow.Decks[MainWindow.indeks].Aboutn;
            Image.Source = MainWindow.Decks[MainWindow.indeks].Img;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
