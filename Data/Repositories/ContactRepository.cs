﻿using Data.DataBaseConnection;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public ApiDbContext _dbContext;

        public ContactRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Contact contact)
        {

           await _dbContext.Contacts.AddAsync(contact);
            
        }

        public void Delete(Contact contact)
        {
            _dbContext.
                Contacts.Remove(contact);
            
        }

        public async Task<List<Contact>> GetAllByUserIdAsync(int userId)
        {
            return await _dbContext.Contacts.Where(contact => contact.UserId == userId).ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _dbContext.
                    Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Update(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            
        }
        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
