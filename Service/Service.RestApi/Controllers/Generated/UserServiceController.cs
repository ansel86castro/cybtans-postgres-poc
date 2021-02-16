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
	[Route("api/User")]
	[ApiController]
	public partial class UserServiceController : ControllerBase
	{
		private readonly IUserService _service;
		
		public UserServiceController(IUserService service)
		{
			_service = service;
		}
		
		[HttpGet("{id}/following")]
		public Task<GetAllUserResponse> GetFollowing(int id, [FromQuery]GetUserFollowingRequest __request)
		{
			__request.Id = id;
			return _service.GetFollowing(__request);
		}
		
		[HttpGet("{id}/followed")]
		public Task<GetAllUserResponse> GetFollowed(int id, [FromQuery]GetUserFollowingRequest __request)
		{
			__request.Id = id;
			return _service.GetFollowed(__request);
		}
		
		[HttpPost("{id}/following")]
		public Task<UserDto> AddFollowing(int id, [FromBody]AddFollowingRequest __request)
		{
			__request.Id = id;
			return _service.AddFollowing(__request);
		}
		
		[HttpDelete("{id}/following/{followingId}")]
		public Task RemoveFollowing(int id, int followingId, [FromQuery]UnFollowingRequest __request)
		{
			__request.Id = id;
			__request.FollowingId = followingId;
			return _service.RemoveFollowing(__request);
		}
		
		[HttpGet]
		public Task<GetAllUserResponse> GetAll([FromQuery]GetAllRequest __request)
		{
			return _service.GetAll(__request);
		}
		
		[HttpGet("{id}")]
		public Task<UserDto> Get(int id, [FromQuery]GetUserRequest __request)
		{
			__request.Id = id;
			return _service.Get(__request);
		}
		
		[HttpPost]
		public Task<UserDto> Create([FromBody]CreateUserRequest __request)
		{
			return _service.Create(__request);
		}
		
		[HttpPut("{id}")]
		public Task<UserDto> Update(int id, [FromBody]UpdateUserRequest __request)
		{
			__request.Id = id;
			return _service.Update(__request);
		}
		
		[HttpDelete("{id}")]
		public Task Delete(int id, [FromQuery]DeleteUserRequest __request)
		{
			__request.Id = id;
			return _service.Delete(__request);
		}
	}

}
