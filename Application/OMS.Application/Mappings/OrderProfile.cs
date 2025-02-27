using AutoMapper;
using OMS.Application.Features.Orders.Dtos;
using OMS.Domain.Entities;

namespace OMS.Application.Mappings;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        // Entity to DTO
        CreateMap<Order, OrderDto>();
    }
}
