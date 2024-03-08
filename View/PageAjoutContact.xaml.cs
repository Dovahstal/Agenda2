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
        MainWindow main;
        public PageAjoutContact(MainWindow main)
        {
            InitializeComponent();
            contact = new Contact();
            this.main = main;
        }
        private void btn_addcontact_click(object sender, RoutedEventArgs e)
        {
            contact.NomContact = TB_NomContact.Text;
            contact.PrenomContact = TB_PrenomContact.Text;
            contact.EmailContact = TB_EmailContact.Text;
            contact.PhoneContact = TB_PhoneContact.Text;
            contact.AdresseContact = TB_AdresseContact.Text;
            contact.CodepostalContact = TB_CodepostalContact.Text;
            contact.VilleContact = TB_VilleContact.Text;
            contact.NaissanceContact = TB_NaissanceContact.Text;
            DAO_contact dao = new DAO_contact();
            dao.AddContact(contact);
        }
    }
}
