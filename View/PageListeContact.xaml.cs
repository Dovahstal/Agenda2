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
using System.Diagnostics.Eventing.Reader;

namespace Agenda2.View
{
    /// <summary>
    /// Logique d'interaction pour PageListeContact.xaml
    /// </summary>
    public partial class PageListeContact : UserControl
    {
        DAO_contact dao_contact;
        DAO_profils dao_profil;

        public PageListeContact()
        {
            InitializeComponent();
            dao_profil = new DAO_profils();
            dao_contact = new DAO_contact();
            var AllContact = dao_contact.GetAllContacts();
            DGContact.ItemsSource = AllContact;
        }

        //bouton de suppression de contact
        private void btn_click_del(object sender, RoutedEventArgs e)
        {
            //défini une variable dell qui vaut la valeur selectionné dans la liste
            var ID = (Contact)DGContact.SelectedItem;

            //pour demander confirmation
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce contact ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //supprime la varaible dell
                dao_contact.DeleteContact(ID.Idcontacts);
                //pour recharger la liste des contact
                var AllContact = dao_contact.GetAllContacts();
                DGContact.ItemsSource = AllContact;
            }
        }

        //confirme les modificiation des attributs d'un contact
        private void btn_mod_click(object sender, RoutedEventArgs e)
        {
            var mod = (Contact)DGContact.SelectedItem;
            dao_contact.UpdateContact(mod);
            var AllContact = dao_contact.GetAllContacts();
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
            btn_profilsrs_contact.IsEnabled = false;
        }

        //affiche les profils de réseaux sociaux d'un contact
        public void btn_profilsrs_click(object sender, RoutedEventArgs e)
        {
            var selectedContact = (Contact)DGContact.SelectedItem;
            if (selectedContact == null)
            {
                MessageBox.Show("Veuillez sélectionner un contact pour voir les profils de ses réseaux sociaux", "Aucun contact sélectionné", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var Profils_by_contact = dao_profil.GetProfilByContactID(selectedContact.Idcontacts);
                DGContact.ItemsSource = Profils_by_contact;
                btn_ajout_contact.IsEnabled = false;
                btn_del_contact.IsEnabled = false;
                btn_mod_contact.IsEnabled = false;
                btn_profilsrs_contact.IsEnabled = false;
            }
        }
    }
}
