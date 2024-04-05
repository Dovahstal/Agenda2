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
    internal class DAO_profils
    {
        //recupere les profils en fonction d'un ID de contact
        public IEnumerable<Profil> GetProfilByContactID(int ID)
        {
            using (var Context = new ContactLongContext())
            {
                var Profils_by_contact = Context.Profils.Where(x => x.ContactIdcontacts == ID).ToList();
                return Profils_by_contact;
            }
        }

        //ajoute un profil à la database
        public string AddProfil(Profil profil)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Profils.Add(profil);
                Context.SaveChanges();
                return "Profil ajouté";
            }
        }

        //supprime un profil de la database
        public string DeleteProfil(int ID)
        {
            using (var Context = new ContactLongContext())
            {
                var itemToRemove = Context.Profils.SingleOrDefault(x => x.Idprofils == ID);
                if (itemToRemove != null)
                {
                    Context.Profils.Remove(itemToRemove);
                    Context.SaveChanges();
                    return "Profil supprimé";
                }
                else
                {
                    return "Profil non trouvé";
                }
            }
        }

        //Modifications d'un profil
        public string UpdateProfil(Profil profil)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Profils.Update(profil);
                Context.SaveChanges();
                return "Profil modifié";
            }
        }
    }
}
