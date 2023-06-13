using Data.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.ApiServices
{
    public class UserServices : IUserService
    {
        public IUsersRepository UserRepository;
        public UserServices(IUsersRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void CreateUser(string nome)
        {
            UserRepository.CreateUser(nome);
        }

        public void DeleteUser(string nome)
        {
            UserRepository.DeleteUser();
        }

        public List<string> GetUsers()
        {
            return UserRepository.GetUsers();
        }

        public void UpdateUser(string nome)
        {
            UserRepository.UpdateUser();
        }
    }
}

//OK
