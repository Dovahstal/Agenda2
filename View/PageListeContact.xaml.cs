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

namespace Agenda2.View
{
    /// <summary>
    /// Logique d'interaction pour PageListeContact.xaml
    /// </summary>
    public partial class PageListeContact : UserControl
    {
        DAO_contact dao = new DAO_contact();
        public PageListeContact()
        {
            InitializeComponent();
            var AllContact = dao.GetAllContacts();
            DGContact.ItemsSource = AllContact;
        }
    }
}
