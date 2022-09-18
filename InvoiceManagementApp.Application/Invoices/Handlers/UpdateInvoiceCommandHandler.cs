using AutoMapper;
using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Application.Invoices.Commands;
using InvoiceManagementApp.Domain.Entities;
using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Handlers;

public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, int>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public UpdateInvoiceCommandHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    public async Task<int> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Invoice>(request);
        context.Invoices.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
