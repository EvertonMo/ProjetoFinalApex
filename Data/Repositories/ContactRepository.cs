﻿using Data.DataBaseConnection;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public ApiDbContext DbContext { get; set; }

        public ContactRepository(ApiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateContact(Contact contact)
        {

            DbContext.Contacts.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            DbContext.
                Contacts.Remove(contact);
        }

        public List<Contact> GetContacts()
        {
            return DbContext.Contacts.ToList();
        }

        public void UpdateContact(Contact contact)
        {
            DbContext.Contacts.Update(contact);
        }
    }
}
