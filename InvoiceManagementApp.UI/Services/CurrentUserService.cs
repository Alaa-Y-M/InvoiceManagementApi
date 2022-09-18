using System.Security.Claims;
using InvoiceManagementApp.Application.Common.Interfaces;

namespace InvoiceManagementApp.UI.Services;

public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor context)
    {
        this.UserId = context.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)! ?? "AlaaDin";
    }
    public string UserId { get; }
}