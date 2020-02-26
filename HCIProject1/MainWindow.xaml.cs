using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HCIProject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataIO Serializer = new DataIO();
        public static BindingList<Deck> Decks { get; set; }
        public static Deck d = new Deck();
        public static int indeks=0;
        public static int indeks1 = 0;

        public MainWindow()
        {

            Decks = Serializer.DeSerializeObject<BindingList<Deck>>("decks.xml");
            if (Decks == null)
            {
                Decks = new BindingList<Deck>();
            }
            DataContext = this;
            InitializeComponent();

            DataGridDecks.ItemsSource = Decks;
                    
        }

        private void Save(object sender, CancelEventArgs e)
        {
            Serializer.SerializeObject<BindingList<Deck>>(Decks, "decks.xml");
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWin = new AddWindow();
            addWin.ShowDialog();
            DataGridDecks.Items.Refresh();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            indeks = DataGridDecks.SelectedIndex;
            WindowOpen WinOpn = new WindowOpen();
            WinOpn.ShowDialog();
        }

        private void Change_Click (object sender, RoutedEventArgs e)
        {
            indeks = DataGridDecks.SelectedIndex;
            d = Decks[indeks];

            WindowChange WinCng = new WindowChange();
            WinCng.ShowDialog();

            Decks[indeks] = d;
            DataGridDecks.Items.Refresh();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Decks.Count > 0)
            {
                Decks.RemoveAt(DataGridDecks.SelectedIndex);
                DataGridDecks.Items.Refresh();
            }  
        }

    }
}
