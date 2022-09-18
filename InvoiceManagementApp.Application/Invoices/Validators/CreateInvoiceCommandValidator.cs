using FluentValidation;
using InvoiceManagementApp.Application.Invoices.Commands;

namespace InvoiceManagementApp.Application.Invoices.Validators;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(v => v.From).NotEmpty().MinimumLength(3);
        RuleFor(v => v.To).NotEmpty().MinimumLength(3);
        RuleFor(v => v.Date).NotNull();
        RuleFor(v => v.InvoiceNumber).NotNull();
        RuleFor(v => v.PaymentTerms).NotNull();
        // RuleFor(v=>v.InvoiceItems).SetValidator();
    }
}