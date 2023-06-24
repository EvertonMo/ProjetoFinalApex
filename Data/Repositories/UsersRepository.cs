using Data.DataBaseConnection;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public ApiDbContext DbContext { get; set; }

        public UsersRepository(ApiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateUser(User user)
        {

            DbContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            DbContext.
                Users.Remove(user);
        }

        public List<User> GetUsers()
        {
            return DbContext.Users.ToList();
        }

        
        public void UpdateUser(User user)
        {
            DbContext.Users.Update(user);
        }
    }
}
