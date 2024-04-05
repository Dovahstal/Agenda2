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
        DAO_events dao_event = new DAO_events();
        DAO_taches dao_taches = new DAO_taches();
        Evenement evenement;
        Tache tache;

        public PageEvenements()
        {
            InitializeComponent();
            var Allevenement = dao_event.GetAllEvenements();
            DGEvents.ItemsSource = Allevenement;
            evenement = new Evenement();
        }

        //boutton affiche un menu différent pour ajouter un evenement
        private void btn_ajoutevent_click(object sender, RoutedEventArgs e)
        {
            liste_evenements.Children.Clear();
            PageAjoutEvent merde = new PageAjoutEvent();
            liste_evenements.Children.Add(merde);
            //desactiver les boutons de modification et de suppression
            btn_mod_event.IsEnabled = false;
            btn_del_event.IsEnabled = false;
            btn_taches_event.IsEnabled = false;

        }

        //boutton de suppression d'evenement
        private void btn_click_delevent(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Voulez-vous vraiment supprimer cet evenement ?", "Suppression", MessageBoxButton.YesNo);
            if (MessageBoxResult.Yes == MessageBox.Show("Annulation"))
            {
                //défini une variable dell qui vaut la valeur selectionné dans la liste
                var del = (Evenement)DGEvents.SelectedItem;
                //supprime la varaible dell
                dao_event.DeleteEvenement(del.Idevenement);
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
            var IDtache = (Evenement)DGEvents.SelectedItem;
            //recupere les taches corespondant à l'id de l'evenement selectionné
            var Taches_by_event = dao_taches.GetTacheByEventID(IDtache.Idevenement);
            DGEvents.ItemsSource = Taches_by_event;
            btn_ajout_event.IsEnabled = false;
            btn_del_event.IsEnabled = false;
            btn_mod_event.IsEnabled = false;
            btn_taches_event.IsEnabled = false;
        }
    }
}
