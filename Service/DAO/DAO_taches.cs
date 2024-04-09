using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Agenda2.Service.DAO;
using Agenda2.Agenda2DB;

namespace Agenda2.Service.DAO
{
    internal class DAO_taches
    {
        //recupere toutes les taches
        public IEnumerable<Tache> GetAllTaches()
        {
            using (var Context = new ContactLongContext())
            {
                var Taches = Context.Taches.ToList();
                return Taches;
            }
        }

        //ajoute une tache à la database
        public string AddTache(Tache tache)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Taches.Add(tache);
                Context.SaveChanges();
                return "Tache ajoutée";
            }
        }

        //supprime une tache de la database
        public string DeleteTache(int ID)
        {
            using (var Context = new ContactLongContext())
            {
                var itemToRemove = Context.Taches.SingleOrDefault(x => x.IdTache == ID);
                if (itemToRemove != null)
                {
                    Context.Taches.Remove(itemToRemove);
                    Context.SaveChanges();
                    return "Tache supprimée";
                }
                else
                {
                    return "Tache non trouvée";
                }
            }
        } 
        
        //Modifie une tache
        public string UpdateTache(Tache tache)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Taches.Update(tache);
                Context.SaveChanges();
                return "Tache modifiée";
            }
        }

        //recupere les taches en fonction d'un ID d'événement
        public IEnumerable<Tache> GetTacheByEventID(int ID)
        {
            using (var Context = new ContactLongContext())
            {
                var Taches_by_event = Context.Taches.Where(x => x.EvenementIdevenement == ID).ToList();
                return Taches_by_event;
            }
        }
        
    }
}
