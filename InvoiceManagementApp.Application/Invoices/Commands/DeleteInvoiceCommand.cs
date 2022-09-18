using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Commands;

public class DeleteInvoiceCommand : IRequest<string>
{
    public int IvoiceId { get; set; }
}