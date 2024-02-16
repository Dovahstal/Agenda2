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
        public IEnumerable<Contact> GetAllContacts()
        {
            using (var Context = new ContactLongContext())
            {
                var AllContact = Context.Contacts.ToList();
                return AllContact;
            }
        }
    }
}
