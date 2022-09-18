using InvoiceManagementApp.Application.Invoices.ViewModels;
using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Query;

public class GetUserInviocesQuery : IRequest<IList<InvoiceVm>>
{
    public string? User { get; set; }
}