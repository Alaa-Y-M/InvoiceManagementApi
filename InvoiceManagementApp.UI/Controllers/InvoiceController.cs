namespace InvoiceManagementApp.UI.Controllers;

using InvoiceManagementApp.Application.Invoices.Commands;
using InvoiceManagementApp.Application.Invoices.Notifications;
using InvoiceManagementApp.Application.Invoices.Query;
using InvoiceManagementApp.Application.Invoices.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class InvoiceController : ApiController
{
    [HttpGet]
    public async Task<IList<InvoiceVm>> GetInvoices()
    {
        return await Mediator.Send(new GetUserInviocesQuery { User = "AlaaDin" });
    }
    [HttpPost]
    public async Task<ActionResult<int>> CreateInvoice(CreateInvoiceCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpPut]
    public async Task<ActionResult<int>> EditInvoice(UpdateInvoiceCommand command)
    {
        return await Mediator.Send(command);
    }
    [HttpDelete]
    public async Task<ActionResult<string>> RemoveInvoice(DeleteInvoiceCommand command)
    {
        await Mediator.Publish(new DeleteInvoiceNotification { Id = command.IvoiceId });
        return await Mediator.Send(command);
    }
}