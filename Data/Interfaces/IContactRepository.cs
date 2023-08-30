using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IContactRepository
    {
        Task CreateAsync(Contact contact);
        Task<List<Contact>> GetAllByUserIdAsync(int userId);
        Task<Contact> GetByIdAsync(int id);
        void Update(Contact contact);
        void Delete(Contact contact);
        Task SaveChangeAsync();
    }
}
