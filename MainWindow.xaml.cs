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
            DGContact.ItemsSource = AllContact;
        }
    }
}