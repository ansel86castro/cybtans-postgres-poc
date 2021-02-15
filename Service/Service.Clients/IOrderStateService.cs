using System;
using Refit;
using Cybtans.Refit;
using System.Net.Http;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Clients
{
	[ApiClient]
	public interface IOrderStateService
	{
		
		[Get("/api/OrderState")]
		Task<GetAllOrderStateResponse> GetAll(GetAllRequest request = null);
		
		[Get("/api/OrderState/{request.Id}")]
		Task<OrderStateDto> Get(GetOrderStateRequest request);
		
		[Post("/api/OrderState")]
		Task<OrderStateDto> Create([Body]CreateOrderStateRequest request);
		
		[Put("/api/OrderState/{request.Id}")]
		Task<OrderStateDto> Update([Body]UpdateOrderStateRequest request);
		
		[Delete("/api/OrderState/{request.Id}")]
		Task Delete(DeleteOrderStateRequest request);
	
	}

}
