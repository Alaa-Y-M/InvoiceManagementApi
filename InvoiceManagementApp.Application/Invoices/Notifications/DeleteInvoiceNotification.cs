using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Notifications;

public class DeleteInvoiceNotification : INotification
{
    public int Id { get; set; }
}
public class EmailHandler : INotificationHandler<DeleteInvoiceNotification>
{
    public Task Handle(DeleteInvoiceNotification notification, CancellationToken cancellationToken)
    {
        //send email to customer
        return Task.CompletedTask;
    }
}
public class SMSHandler : INotificationHandler<DeleteInvoiceNotification>
{
    public Task Handle(DeleteInvoiceNotification notification, CancellationToken cancellationToken)
    {
        //send sms to customer
        return Task.CompletedTask;
    }
}
