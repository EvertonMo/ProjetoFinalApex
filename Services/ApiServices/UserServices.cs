using Data.Interfaces;
using Data.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ultils.Dtos.Contact;

namespace Services.ApiServices
{
    public class UserServices : IUserService
    {
        private readonly IUsersRepository _userRepository;
        public UserServices(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(UserCreatRequestDto userCreateDto)
        {
            var user = new User()
            {
                Name = userCreateDto.Name,
                Email = userCreateDto.Email,
                Password = userCreateDto.Password,
                Role = "consumer",
                CreadAt = DateTime.Now

            };

           await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangeAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user =await _userRepository.GetByIdAsync(id);
            
            if (user != null) 
            {
            _userRepository.Delete(user);
                await _userRepository.SaveChangeAsync();
          
                return true;
            }
            return false;

        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var users =await _userRepository.GetAllAsync();

            var userDtos = new List<UserResponseDto>();

            foreach (var userModel in users)
            {
                var userDto = new UserResponseDto()
                {
                    Id = userModel.Id,
                    Email = userModel.Email,
                    Name = userModel.Name,
                    Contacts = GetContactDtosList(userModel.Contacts)
                };
                userDtos.Add(userDto);
            }
            return userDtos;
        }

        public async Task<bool> UpdateAsync(UserUpdateRequestDto userUpdateDto)
        {
            var userFound =await _userRepository.GetByIdAsync(userUpdateDto.Id);

            if (userFound != null)
            {
                userFound.Name = userUpdateDto.Name;
                userFound.Email = userUpdateDto.Email;
            
                userFound.UpdateAt = DateTime.Now;
                _userRepository.Update(userFound);
                await _userRepository.SaveChangeAsync();
                return true;
            }
            return false;

            
        }

        public async Task UpdateToAdmin(int userId)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId);

            if (existingUser != null)
            {
                existingUser.Role = "admin";
                existingUser.UpdateAt = DateTime.Now;

                _userRepository.Update(existingUser);

                await _userRepository.SaveChangeAsync();
            }
        }

        private List<BaseContactDto> GetContactDtosList(List<Contact> contactModels)
        {
            var contactDtos = new List<BaseContactDto>();

            foreach (var contactModel in contactModels) 
            {
                contactDtos.Add(
                    new BaseContactDto()
                {
                    Name = contactModel.Name,
                    Phone = contactModel.Phone
                }
                );
                
            }
            return contactDtos;
        }
    }

}

//OK
