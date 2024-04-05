using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Agenda2.Agenda2DB;

namespace Agenda2.Service.DAO
{
    class DAO_events
    {
        //Récupére tout les événements de la database
        public IEnumerable<Evenement> GetAllEvenements()
        {
            using (var Context = new ContactLongContext())
            {
                var AllEvents = Context.Evenements.ToList();
                return AllEvents;
            }
        }

        //Ajoute un événement à la database
        public string AddEvenement(Evenement evenement)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Evenements.Add(evenement);
                Context.SaveChanges();
                return "Evenement ajouté";
            }
        }

        //supprime un événement de la database
        public string DeleteEvenement(int ID)
        {
            using (var Context = new ContactLongContext())
            {
                var itemToRemove = Context.Contacts.SingleOrDefault(x => x.Idcontacts == ID);
                if (itemToRemove != null)
                {
                    Context.Contacts.Remove(itemToRemove);
                    Context.SaveChanges();
                    return "Artiste supprimé";
                }
                else
                {
                    return "Artiste non trouvé";
                }
            }
        }

        //Confirme les modifications d'un événement
        public string UpdateEvent(Evenement evenement)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Evenements.Update(evenement);
                Context.SaveChanges();
                return "Evenement modifié";
            }
        }
    }
}