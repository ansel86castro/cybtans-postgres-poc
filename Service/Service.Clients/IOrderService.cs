using System;
using Refit;
using Cybtans.Refit;
using System.Net.Http;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Clients
{
	[ApiClient]
	public interface IOrderService
	{
		
		[Get("/api/Order")]
		Task<GetAllOrderResponse> GetAll(GetAllRequest request = null);
		
		[Get("/api/Order/{request.Id}")]
		Task<OrderDto> Get(GetOrderRequest request);
		
		[Post("/api/Order")]
		Task<OrderDto> Create([Body]CreateOrderRequest request);
		
		[Put("/api/Order/{request.Id}")]
		Task<OrderDto> Update([Body]UpdateOrderRequest request);
		
		[Delete("/api/Order/{request.Id}")]
		Task Delete(DeleteOrderRequest request);
	
	}

}
