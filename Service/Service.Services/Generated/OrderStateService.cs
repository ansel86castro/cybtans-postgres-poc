
using System;
using AutoMapper;
using Cybtans.Entities;
using Cybtans.Services;
using Microsoft.Extensions.Logging;
using Service.Domain;
using Service.Models;

namespace Service.Services
{
    [RegisterDependency(typeof(IOrderStateService))]
    public class OrderStateService : CrudService<OrderState, int, OrderStateDto, GetOrderStateRequest, GetAllRequest, GetAllOrderStateResponse, UpdateOrderStateRequest, CreateOrderStateRequest, DeleteOrderStateRequest>, IOrderStateService
    {
        public OrderStateService(IRepository<OrderState, int> repository, IUnitOfWork uow, IMapper mapper, ILogger<OrderStateService> logger)
            : base(repository, uow, mapper, logger) { }                
    }
}