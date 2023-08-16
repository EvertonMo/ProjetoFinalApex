using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ultils.Dtos.Contact;

namespace Services.Interfaces
{
    public interface IContactService
    {
        Task<bool> CreateAsync(ContactCreatRequestDto contactCreateDto);
        Task<List<ContactResponseDto>> GetAllAsync();
        Task<bool> UpdateAsync(ContactUpdateRequestDto contactUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}



//CORRIGIDO