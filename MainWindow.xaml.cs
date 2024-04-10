using Agenda2.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agenda2.Service.DAO;
using Agenda2.Agenda2DB;

namespace Agenda2
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

        private void btn_evenement_click(object sender, RoutedEventArgs e)
        {
            partie_changeante.Children.Clear();
            PageEvenements merde = new PageEvenements();
            partie_changeante.Children.Add(merde);
        }

        private void btn_contact_click(object sender, RoutedEventArgs e)
        {
            partie_changeante.Children.Clear();
            PageListeContact merde = new PageListeContact();
            partie_changeante.Children.Add(merde);
        }

        private void btn_taches_click(object sender, RoutedEventArgs e)
        {
            partie_changeante.Children.Clear();
            PageListeTache merde = new PageListeTache();
            partie_changeante.Children.Add(merde);

        }

        private void btn_sortie_click(object sender, RoutedEventArgs e)
        {
            //ferme l'application après avoir demandé une confirmation
            MessageBoxResult result = MessageBox.Show("Voulez-vous fermer l'agenda ?", "Bouton de fermeture", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }
    }
}