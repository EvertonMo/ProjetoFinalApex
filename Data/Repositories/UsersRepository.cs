using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public void CreateUser(string nome)
        {
            
        }

        public void DeleteUser()
        {
            
        }

        public List<string> GetUsers()
        {
            return new List<string>() { "Jõao", "Carlos", "Fernanda" };
        }

        public void UpdateUser()
        {
            
        }
    }
}
