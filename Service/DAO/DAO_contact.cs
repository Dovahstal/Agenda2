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
        //Récupére tout les contacts de la database
        public IEnumerable<Contact> GetAllContacts()
        {
            using (var Context = new ContactLongContext())
            {
                var AllContact = Context.Contacts.ToList();
                return AllContact;
            }
        }

        //Ajoute un contact à la database
        public string AddContact(Contact contact)
        {
            using (var Context = new ContactLongContext())
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
                return "Artiste ajouté";
            }
        }

        //Récupére tout les contacts qui commencent par une lettre spécifié
        public IEnumerable<Contact> GetContactsStartsByName(string name) 
        {
            using (var Context = new ContactLongContext())
            {
                var Contact_by_name = Context.Contacts.Where(x => x.NomContact.StartsWith(name)).ToList();
                return Contact_by_name;
            }
        }

        //Supprime un contact de la database
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

        //Modifie un contact de la database
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