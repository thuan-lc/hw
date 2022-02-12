using LibraryManagementAPI.Domains;
using LibraryManagementAPI.Enums;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password, int userRole);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
