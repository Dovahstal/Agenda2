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
        DAO_contact dao = new DAO_contact();

        public MainWindow()
        {
            InitializeComponent();
            var AllContact = dao.GetAllContacts();
        }

        //private void btn_evenement_click(object sender, RoutedEventArgs e)
        //{
        //    partie_changeante.Children.Clear();
        //    PageEvenements merde = new PageEvenements();
        //    partie_changeante.Children.Add(merde);
        //}

        private void btn_listecontact_clicl(object sender, RoutedEventArgs e)
        {
            partie_changeante.Children.Clear();
            PageListeContact merde = new PageListeContact();
            partie_changeante.Children.Add(merde);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            partie_changeante.Children.Clear();
            PageListeContact merde = new PageListeContact();
            partie_changeante.Children.Add(merde);
        }
    }
}