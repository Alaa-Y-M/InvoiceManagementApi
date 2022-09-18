using AutoMapper;
using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Application.Invoices.Commands;
using InvoiceManagementApp.Domain.Entities;
using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Handlers;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public CreateInvoiceCommandHandler(IApplicationDbContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Invoice>(request);
        await context.Invoices.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
