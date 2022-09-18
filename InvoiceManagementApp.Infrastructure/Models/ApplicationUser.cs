using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApp.Infrastructure.Models;

public class ApplicationUser : IdentityUser
{
    public IList<RefreshToken>? RefreshTokens { get; set; }
}