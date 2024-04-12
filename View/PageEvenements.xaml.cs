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
    /// Logique d'interaction pour PageEvenements.xaml
    /// </summary>
    public partial class PageEvenements : UserControl
    {
        DAO_events dao_event;
        DAO_taches dao_taches;
    
        Tache tache;

        public PageEvenements()
        {
            InitializeComponent();
            dao_event = new DAO_events();
            dao_taches = new DAO_taches();
    
            var Allevenement = dao_event.GetAllEvenements();
            DGEvents.ItemsSource = Allevenement;
        }

        //boutton affiche un menu différent pour ajouter un evenement
        private void btn_ajoutevent_click(object sender, RoutedEventArgs e)
        {
            liste_evenements.Children.Clear();
            PageAjoutEvent nouvellepage = new PageAjoutEvent();
            liste_evenements.Children.Add(nouvellepage);
            //desactiver les boutons de modification et de suppression
            btn_mod_event.IsEnabled = false;
            btn_del_event.IsEnabled = false;
            btn_taches_event.IsEnabled = false;

        }

        //boutton de suppression d'evenement
        private void btn_click_delevent(object sender, RoutedEventArgs e)
        {
            var ID = (Evenement)DGEvents.SelectedItem;

            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cet evenement ?", "Confirmation de suppresion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //supprimer  l'evenement selectionné
                dao_event.DeleteEvenement(ID.Idevenement);
                //réactualise la liste de la database
                var Allevenement = dao_event.GetAllEvenements();
                //réactualise la liste affiché
                DGEvents.ItemsSource = Allevenement;
            }

        }

        //confirme les modificiation des attributs d'un evenement
        private void btn_modevent_click(object sender, RoutedEventArgs e)
        {
            var mod = (Evenement)DGEvents.SelectedItem;
            dao_event.UpdateEvent(mod);
            var Allevenement = dao_event.GetAllEvenements();
            DGEvents.ItemsSource = Allevenement;
        }

        private void btn_taches_click(object sender, RoutedEventArgs e)
        {
            //recupere l'id de l'evenement selectionné
            var selectedIDEvent = (Evenement)DGEvents.SelectedItem;

            // Vérifie si aucun événement n'est sélectionné
            if (selectedIDEvent == null)
            {
                MessageBox.Show("Veuillez sélectionner un événement pour voir les taches associées.", "Aucun événement sélectionné");
                return;
            }

            //recupere les taches correspondant à l'id de l'evenement selectionné
            var Taches_by_event = dao_taches.GetTacheByEventID(selectedIDEvent.Idevenement);
            DGEvents.ItemsSource = Taches_by_event;
            btn_ajout_event.IsEnabled = false;
            btn_del_event.IsEnabled = false;
            btn_mod_event.IsEnabled = false;
            btn_taches_event.IsEnabled = false;

        }
    }
}
