using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Domain.Common;
using InvoiceManagementApp.Domain.Entities;
using InvoiceManagementApp.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApp.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    // private readonly ICurrentUserService service;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // service = _service;
    }
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=InvoiceDB;Trusted_Connection=True;MultipleActiveResultSets=True",
        opt => opt.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Invoice>().HasMany(i => i.InvoiceItems);
        base.OnModelCreating(builder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries<AuditEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "AlaaDin";
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = "AlaaDin";
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}