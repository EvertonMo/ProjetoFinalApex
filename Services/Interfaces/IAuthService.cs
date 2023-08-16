using System.Threading.Tasks;
using Ultils.Dtos.Auth;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginRequestDto loginRequestDto);
    }
}


