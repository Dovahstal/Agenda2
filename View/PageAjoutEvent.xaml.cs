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
    /// Logique d'interaction pour PageAjoutEvent.xaml
    /// </summary>
    public partial class PageAjoutEvent : UserControl
    {
        Evenement evenement;

        public PageAjoutEvent()
        {
            evenement = new Evenement();
            InitializeComponent();
        }


        //efface le texte dans les textbox quand la souris passe dessus
        private void EffacerTexteTextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
        }

        private void btn_addevent_click(object sender, RoutedEventArgs e)
        { 
            //recupere les valeurs des textbox et les attribut aux attributs de la classe evenement
            evenement.NomEvenement = TB_NomEvent.Text;

            //ajoute l'evenement à la database avec les attributs récupérés
            DAO_events dao = new DAO_events();
            dao.AddEvenement(evenement);
        }


        
    }
}
