using InvoiceManagementApp.Application.Common.Models;

namespace InvoiceManagementApp.Application.Common.Interfaces;

public interface IAuthService
{
    Task<AuthModel> RegisterAsync(RegisterModel model);
    Task<AuthModel> LoginAsync(LoginModel model);
    Task<string> AddToRoleAsync(RoleModel model);
    Task<AuthModel> RefreshTokenAsync(string token);
    Task<bool> RevokeTokenAsync(string token);
}