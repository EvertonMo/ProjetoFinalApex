﻿using Data.Interfaces;
using Data.Models;
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

        public void CreateUser(User user)
        {
            UserRepository.CreateUser(user);
        }

        public void DeleteUser(User user)
        {
            UserRepository.DeleteUser(user);
        }

        public List<User> GetUsers()
        {
            return UserRepository.GetUsers();
        }

        public void UpdateUser(User user)
        {
            UserRepository.UpdateUser(user);
        }
    }
}

//OK
