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
    /// Logique d'interaction pour PageAjoutTache.xaml
    /// </summary>
    public partial class PageAjoutTache : UserControl
    {
        Tache tache;
        public PageAjoutTache()
        {
            InitializeComponent();
        }

        //efface le texte dans les textbox quand la souris passe dessus
        private void EffacerTexteTextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
        }

        //ajoute une tache à la database avec les attributs récupérés dans les textbox
        private void btn_addtache_click(object sender, RoutedEventArgs e)
        {
            tache = new Tache();
            tache.NomTache = TB_NomTache.Text;
            tache.DatelimTache = TB_DateLimTache.Text;
            tache.EvenementIdevenement = int.Parse(TB_IDEventDeTache.Text);
            DAO_taches dao = new DAO_taches();
            dao.AddTache(tache);
            MessageBox.Show("Tâche ajoutée");
        }
    }
}
