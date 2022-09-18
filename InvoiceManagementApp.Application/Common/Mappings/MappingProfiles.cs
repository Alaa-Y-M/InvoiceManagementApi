using AutoMapper;
using InvoiceManagementApp.Application.Invoices.Commands;
using InvoiceManagementApp.Application.Invoices.ViewModels;
using InvoiceManagementApp.Domain.Entities;

namespace InvoiceManagementApp.Application.Common.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<InvoiceItem, InvoiceItemVm>().ForMember(m => m.Amount, opt => opt.Ignore()).ReverseMap();
        CreateMap<InvoiceItem, UpdateInvoiceItemVm>().ReverseMap();
        CreateMap<CreateInvoiceCommand, Invoice>().ReverseMap();
        CreateMap<UpdateInvoiceCommand, Invoice>().ReverseMap();
        CreateMap<InvoiceVm, Invoice>().ReverseMap();
    }
}