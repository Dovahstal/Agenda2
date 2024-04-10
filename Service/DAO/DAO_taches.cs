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
        //Cette fonction recupere toutes les taches de la database
        public IEnumerable<Tache> GetAllTaches()
        {
            using (var Context = new ContactLongContext())
            {
                var Taches = Context.Taches.ToList();
                return Taches;
            }
        }

        //Cette fonction ajoute une tache à la database
        public string AddTache(Tache tache)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Taches.Add(tache);
                Context.SaveChanges();
                return "Tache ajoutée";
            }
        }

        //Cette fonction supprime une tache de la database en fonction de son ID
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

        //Cette fonction modifie les attributs d'une tache dans la database
        public string UpdateTache(Tache tache)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Taches.Update(tache);
                Context.SaveChanges();
                return "Tache modifiée";
            }
        }

        //Cette fonction récupére les taches associé a un événement par l'ID de l'événement
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
