using System;
using System.Threading.Tasks;
using Service.Models;
using System.Collections.Generic;

namespace Service.Services
{
	public partial interface IOrderService 
	{
		
		Task<GetAllOrderResponse> GetAll(GetAllRequest request);
		
		
		Task<OrderDto> Get(GetOrderRequest request);
		
		
		Task<OrderDto> Create(CreateOrderRequest request);
		
		
		Task<OrderDto> Update(UpdateOrderRequest request);
		
		
		Task Delete(DeleteOrderRequest request);
		
	}

}
