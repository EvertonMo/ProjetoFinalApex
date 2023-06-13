using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IUsersRepository
    {
        void CreateUser(string nome);
        List<string> GetUsers();
        void UpdateUser();
        void DeleteUser();
    }
}
