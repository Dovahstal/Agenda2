﻿using Agenda2.Agenda2DB;
using Agenda2.Service.DAO;
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

namespace Agenda2.View
{
    /// <summary>
    /// Logique d'interaction pour PageListeTache.xaml
    /// </summary>
    public partial class PageListeTache : UserControl
    {
        DAO_taches dao_tache;

        public PageListeTache()
        {
            InitializeComponent();
            dao_tache = new DAO_taches();
            var AllTaches = dao_tache.GetAllTaches();
            DGTache.ItemsSource = AllTaches;
        }

        private void btn_ajoutache_click(object sender, RoutedEventArgs e)
        {
            liste_taches.Children.Clear();
            PageAjoutTache nouvellepage = new PageAjoutTache();
            liste_taches.Children.Add(nouvellepage);
        }

        private void btn_deltache_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette tache ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var ID = (Tache)DGTache.SelectedItem;
                dao_tache.DeleteTache(ID.IdTache);
                var AllTaches = dao_tache.GetAllTaches();
                DGTache.ItemsSource = AllTaches;
            }

        }

        private void btn_modtache_click(object sender, RoutedEventArgs e)
        {
            var mod = (Tache)DGTache.SelectedItem;
            if (mod == null)
            {
                MessageBox.Show("Veuillez sélectionner une tache a modifier", "Aucune tache sélectionnée", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                dao_tache.UpdateTache(mod);
                var AllTaches = dao_tache.GetAllTaches();
                DGTache.ItemsSource = AllTaches;
            }
        }
    }
}
