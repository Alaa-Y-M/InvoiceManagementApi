using InvoiceManagementApp.Application.Invoices.ViewModels;
using InvoiceManagementApp.Domain.Enums;
using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Commands;

public class UpdateInvoiceCommand : IRequest<int>
{
    public UpdateInvoiceCommand()
    {
        this.InvoiceItems = new List<UpdateInvoiceItemVm>();
    }
    public int Id { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public string From { get; set; } = null!;
    public string To { get; set; } = null!;
    public string Logo { get; set; } = null!;
    public double AmountPaid { set; get; }
    public string PaymentTerms { set; get; } = null!;
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public double Tax { get; set; }
    public TaxType TaxType { get; set; }
    public double Discount { get; set; }
    public DiscountType DiscountType { get; set; }
    public IList<UpdateInvoiceItemVm> InvoiceItems { get; set; }
}