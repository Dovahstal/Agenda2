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
        //Cette fonction récupére un profil de contact par son ID
        public IEnumerable<Profil> GetProfilByContactID(int ID)
        {
            using (var Context = new ContactLongContext())
            {
                var Profils_by_contact = Context.Profils.Where(x => x.ContactIdcontacts == ID).ToList();
                return Profils_by_contact;
            }
        }

        //Cette fonction ajoute un profil à la database
        public string AddProfil(Profil profil)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Profils.Add(profil);
                Context.SaveChanges();
                return "Profil ajouté";
            }
        }

        //Cette fonction supprime un profil de la database en fonction de son ID
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

        //Cette fonction modifie les attributs d'un profil dans la database
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
