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

        private void btn_click_del(object sender, RoutedEventArgs e)
        {
            //défini une variable dell qui vaut la valeur selectionné dans la liste
            var dell = (Contact)DGContact.SelectedItem;
            //supprime la varaible dell
            dao.DeleteContact(dell.Idcontacts);
            //réactualise la liste de la database
            var AllContact = dao.GetAllContacts();
            //réactualise la liste affiché
            DGContact.ItemsSource = AllContact;
        }
    }
}
