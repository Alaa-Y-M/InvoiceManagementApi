using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Application.Invoices.Commands;
using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Handlers;

public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, string>
{
    private readonly IApplicationDbContext context;

    public DeleteInvoiceCommandHandler(IApplicationDbContext _context)
    {
        context = _context;
    }
    public async Task<string> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Invoices.FindAsync(request.IvoiceId);
        if (entity is null)
            return "error!";
        context.Invoices.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
        return "deleted successfully!";
    }
}
