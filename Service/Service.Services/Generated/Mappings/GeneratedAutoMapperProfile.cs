
using System;
using AutoMapper;
using Service.Domain;
using Service.Models;

namespace Service.Services
{
    public class GeneratedAutoMapperProfile:Profile
    {
        public GeneratedAutoMapperProfile()
        {
           
           CreateMap<Customer, CustomerDto>();
           CreateMap<CustomerDto,Customer>();
           
           CreateMap<CustomerProfile, CustomerProfileDto>();
           CreateMap<CustomerProfileDto,CustomerProfile>();
           
           CreateMap<Order, OrderDto>();
           CreateMap<OrderDto,Order>();
           
           CreateMap<OrderState, OrderStateDto>();
           CreateMap<OrderStateDto,OrderState>();
           
           CreateMap<OrderItem, OrderItemDto>();
           CreateMap<OrderItemDto,OrderItem>();
        
        }
    }
}