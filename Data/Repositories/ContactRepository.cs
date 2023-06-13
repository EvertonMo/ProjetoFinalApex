using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public void CreateContact(string nome)
        {
            
        }

        public void DeleteContact()
        {
            
        }

        public List<string> GetContacts()
        {
            return new List<string>() { "Tio Nal", "Tia Zene", "Vô Eraldo" };
        }

        public void UpdateContact()
        {
            
        }
    }
}
