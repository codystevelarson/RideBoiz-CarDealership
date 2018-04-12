using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class ContactRepositoryTEST : IContactRepository
    {
        private static List<Contact> _contacts;

        public ContactRepositoryTEST()
        {
            _contacts = new List<Contact>();
        }

        public Contact Add(Contact contact)
        {
            if(_contacts.Any())
            {
                contact.ContactId = _contacts.Max(c => c.ContactId) + 1;
            }
            else
            {
                contact.ContactId = 1;
            }
            _contacts.Add(contact);
            return contact;
        }
    }
}
