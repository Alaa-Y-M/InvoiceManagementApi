using InvoiceManagementApp.Domain.Common;

namespace InvoiceManagementApp.Domain.Entities;

public class InvoiceItem : AuditEntity
{
    public int Id { set; get; }
    public int InvoiceId { set; get; }
    public string Item { set; get; } = null!;
    public double Quantity { set; get; }
    public double Rate { set; get; }
    public Invoice Invoice { set; get; } = null!;
}