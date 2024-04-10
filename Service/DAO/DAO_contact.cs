using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Agenda2.Agenda2DB;


namespace Agenda2.Service.DAO
{
    class DAO_contact
    {
        //Cette fonction récupére tout les contacts de la database
        public IEnumerable<Contact> GetAllContacts()
        {
            using (var Context = new ContactLongContext())
            {
                var AllContact = Context.Contacts.ToList();
                return AllContact;
            }
        }

        //Cette fonction ajoute un contact à la database
        public string AddContact(Contact contact)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
                return "Artiste ajouté";
            }
        }

        //Cette fonction récupére un contact par son ID
        public string DeleteContact(int ID)
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

        //Cette fonction modifie les attributs d'un contact dans la database
        public void UpdateContact(Contact contact)
        {
            using (var Context = new ContactLongContext())
            {
                
                Context.Contacts.Update(contact);
                Context.SaveChanges();
            }
        }
    }
}