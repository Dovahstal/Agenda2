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
        Contact contact;

        public PageListeContact()
        {
            InitializeComponent();
            var AllContact = dao.GetAllContacts();
            DGContact.ItemsSource = AllContact;
            contact = new Contact();
        }

        //bouton de suppression de contact
        private void btn_click_del(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Voulez-vous vraiment supprimer ce contact ?", "Suppression", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == MessageBox.Show("Annulation"))
            {
                //défini une variable dell qui vaut la valeur selectionné dans la liste
                var del = (Contact)DGContact.SelectedItem;
                //supprime la varaible dell
                dao.DeleteContact(del.Idcontacts);
                //réactualise la liste de la database
                var AllContact = dao.GetAllContacts();
                //réactualise la liste affiché
                DGContact.ItemsSource = AllContact;
            }
        }

        //confirme les modificiation des attributs d'un contact
        private void btn_mod_click(object sender, RoutedEventArgs e)
        {
            var mod = (Contact)DGContact.SelectedItem;
            dao.UpdateContact(mod);
            var AllContact = dao.GetAllContacts();
            DGContact.ItemsSource = AllContact;
        }

        //affiche un menu différent pour ajouter un contact
        private void btn_ajoutcontact_click(object sender, RoutedEventArgs e)
        {
            liste_contact.Children.Clear();
            PageAjoutContact merde = new PageAjoutContact();
            liste_contact.Children.Add(merde);
            //desactive supprimer contact et modifier contact quand on clique sur ajouter contact
            btn_del_contact.IsEnabled = false;
            btn_mod_contact.IsEnabled = false;
        }

    }
}
