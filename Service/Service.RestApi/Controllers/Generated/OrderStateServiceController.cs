using System;
using Service.Services;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cybtans.AspNetCore;

namespace Service.Controllers
{
	[Route("api/OrderState")]
	[ApiController]
	public partial class OrderStateServiceController : ControllerBase
	{
		private readonly IOrderStateService _service;
		
		public OrderStateServiceController(IOrderStateService service)
		{
			_service = service;
		}
		
		[HttpGet]
		public Task<GetAllOrderStateResponse> GetAll([FromQuery]GetAllRequest __request)
		{
			return _service.GetAll(__request);
		}
		
		[HttpGet("{id}")]
		public Task<OrderStateDto> Get(int id, [FromQuery]GetOrderStateRequest __request)
		{
			__request.Id = id;
			return _service.Get(__request);
		}
		
		[HttpPost]
		public Task<OrderStateDto> Create([FromBody]CreateOrderStateRequest __request)
		{
			return _service.Create(__request);
		}
		
		[HttpPut("{id}")]
		public Task<OrderStateDto> Update(int id, [FromBody]UpdateOrderStateRequest __request)
		{
			__request.Id = id;
			return _service.Update(__request);
		}
		
		[HttpDelete("{id}")]
		public Task Delete(int id, [FromQuery]DeleteOrderStateRequest __request)
		{
			__request.Id = id;
			return _service.Delete(__request);
		}
	}

}
