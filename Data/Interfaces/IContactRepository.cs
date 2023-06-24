using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IContactRepository
    {
        void CreateContact(Contact contact);
        List<Contact> GetContacts();
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
