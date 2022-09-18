using InvoiceManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Invoice> Invoices { set; get; }
    DbSet<InvoiceItem> InvoiceItems { set; get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}