
using System;
using AutoMapper;
using Cybtans.Entities;
using Cybtans.Services;
using Microsoft.Extensions.Logging;
using Service.Domain;
using Service.Models;

namespace Service.Services
{
    [RegisterDependency(typeof(IOrderService))]
    public class OrderService : CrudService<Order, Guid, OrderDto, GetOrderRequest, GetAllRequest, GetAllOrderResponse, UpdateOrderRequest, CreateOrderRequest, DeleteOrderRequest>, IOrderService
    {
        public OrderService(IRepository<Order, Guid> repository, IUnitOfWork uow, IMapper mapper, ILogger<OrderService> logger)
            : base(repository, uow, mapper, logger) { }                
    }
}