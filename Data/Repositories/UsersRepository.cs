using Data.DataBaseConnection;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApiDbContext _dbContext;

        public UsersRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User user)
        {

            await _dbContext.Users.AddAsync(user);

        }

        public async Task<User> GetByEmalandPasswordAsync(string email, string password)
        {
            return await _dbContext.
                    Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public void Delete(User user)
        {
            
            _dbContext.Users.Remove(user);
           
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.Include(usuarios => usuarios.Contacts).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.
                    Users.FirstOrDefaultAsync(x => x.Id == id);
        }


        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
