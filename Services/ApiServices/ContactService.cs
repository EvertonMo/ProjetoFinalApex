using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Ultils.Dtos.Contact;

namespace Services.ApiServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUsersRepository _usersRepository;

        public ContactService(
            IContactRepository contactRepository, 
            IUsersRepository usersRepository)
        {
            _contactRepository = contactRepository;
            _usersRepository = usersRepository;
        }
        public async Task<bool> CreateAsync(ContactCreatRequestDto contactCreatDto)
        {
            var user =await _usersRepository.GetByIdAsync(contactCreatDto.UserId);

            if (user != null)
            {
                var contact = new Contact()
                {
                    Name = contactCreatDto.Name,
                    Phone = contactCreatDto.Phone,
                    UserId = contactCreatDto.UserId,
                    CreadAt = DateTime.Now
                };
                await _contactRepository.CreateAsync(contact);
                await _contactRepository.SaveChangeAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact =await _contactRepository.GetByIdAsync(id);

            if (contact != null)
            {
                _contactRepository.Delete(contact);
                await _contactRepository.SaveChangeAsync();
                return true;
            }
            return false;
        }


            public async Task<List<ContactResponseDto>> GetAllAsync()
        {
            var contacts =await _contactRepository.GetAllAsync();
            var contactDtos = new List<ContactResponseDto>();

            foreach (var contactModel in contacts)
            {
                contactDtos.Add(new ContactResponseDto()
                {
                    Id = contactModel.Id,
                    Name = contactModel.Name,
                    Phone = contactModel.Phone,
                    UserId = contactModel.UserId
                });
            }
            return contactDtos;
        }

        public async Task<bool> UpdateAsync(ContactUpdateRequestDto contactUpdateDto)
        {
            var contactFound =await _contactRepository.GetByIdAsync(contactUpdateDto.Id);

            if (contactFound != null)
            {
                contactFound.Name = contactUpdateDto.Name;
                contactFound.Phone = contactUpdateDto.Phone;

                contactFound.UpdateAt = DateTime.Now;

                _contactRepository.Update(contactFound);
                await _contactRepository.SaveChangeAsync();
                return true;
            }
            return false;
        }
    }
}

//CORRIGIDO