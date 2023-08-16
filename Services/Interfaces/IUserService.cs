using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ultils.Dtos.Contact;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(UserCreatRequestDto userCreateDto);
        Task<List<UserResponseDto>> GetAllAsync();
        Task<bool> UpdateAsync(UserUpdateRequestDto userUpdateDto);
        Task<bool> DeleteAsync(int id );
        Task UpdateToAdmin(int userId);
        
    }
}


//CORRIGIDO