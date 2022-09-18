using AutoMapper;
using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Application.Invoices.Query;
using InvoiceManagementApp.Application.Invoices.ViewModels;
using InvoiceManagementApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApp.Application.Invoices.Handlers;

public class GetUserInviocesQueryHandlers : IRequestHandler<GetUserInviocesQuery, IList<InvoiceVm>>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetUserInviocesQueryHandlers(IApplicationDbContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    public async Task<IList<InvoiceVm>> Handle(GetUserInviocesQuery request, CancellationToken cancellationToken)
    {
        var data = await context.Invoices
        .Include(i => i.InvoiceItems)
        .Where(i => i.CreatedBy == request.User || i.LastModifiedBy == request.User)
        .ToListAsync();
        if (data is null)
            return new List<InvoiceVm>();
        var invoices = mapper.Map<IList<InvoiceVm>>(data);
        return invoices;
    }
}