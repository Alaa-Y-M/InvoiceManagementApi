using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementApp.UI.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    private IMediator? mediator;
    protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}