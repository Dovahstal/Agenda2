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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agenda2.Service.DAO;
using Agenda2.Agenda2DB;
using static System.Net.Mime.MediaTypeNames;

namespace Agenda2.View
{
    /// <summary>
    /// Logique d'interaction pour PageAjoutContact.xaml
    /// </summary>
    public partial class PageAjoutContact : UserControl
    {
        Contact contact;

        public PageAjoutContact()
        {
            InitializeComponent();
            contact = new Contact();
          
        }
        private void btn_addcontact_click(object sender, RoutedEventArgs e)
        {
            //récupére les valeurs des textbox et les attribut aux attributs de la classe contact
            contact.NomContact = TB_NomContact.Text;
            contact.PrenomContact = TB_PrenomContact.Text;
            contact.EmailContact = TB_EmailContact.Text;
            contact.PhoneContact = TB_PhoneContact.Text;
            contact.AdresseContact = TB_AdresseContact.Text;
            contact.CodepostalContact = TB_CodepostalContact.Text;
            contact.VilleContact = TB_VilleContact.Text;
            contact.NaissanceContact = TB_NaissanceContact.Text;
            //ajoute le contact à la database avec les attributs récupérés
            DAO_contact dao = new DAO_contact();
            dao.AddContact(contact);
        }

        //efface le texte dans les textbox
        private void EffacerTexteTextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
        }
    }
}
