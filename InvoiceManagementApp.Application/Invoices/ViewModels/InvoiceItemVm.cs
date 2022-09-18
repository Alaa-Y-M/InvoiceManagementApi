namespace InvoiceManagementApp.Application.Invoices.ViewModels;

public class InvoiceItemVm
{
    public string Item { set; get; } = null!;
    public double Quantity { set; get; }
    public double Rate { set; get; }
    public double Amount
    {
        get
        {
            return Quantity * Rate;
        }
    }


}