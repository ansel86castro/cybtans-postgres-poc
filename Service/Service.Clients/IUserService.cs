using System;
using Refit;
using Cybtans.Refit;
using System.Net.Http;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Clients
{
	[ApiClient]
	public interface IUserService
	{
		
		[Get("/api/User/{request.Id}/following")]
		Task<GetAllUserResponse> GetFollowing(GetUserFollowingRequest request);
		
		[Get("/api/User/{request.Id}/followed")]
		Task<GetAllUserResponse> GetFollowed(GetUserFollowingRequest request);
		
		[Post("/api/User/{request.Id}/following")]
		Task<UserDto> AddFollowing([Body]AddFollowingRequest request);
		
		[Delete("/api/User/{request.Id}/following/{request.FollowingId}")]
		Task RemoveFollowing(UnFollowingRequest request);
		
		[Get("/api/User")]
		Task<GetAllUserResponse> GetAll(GetAllRequest request = null);
		
		[Get("/api/User/{request.Id}")]
		Task<UserDto> Get(GetUserRequest request);
		
		[Post("/api/User")]
		Task<UserDto> Create([Body]CreateUserRequest request);
		
		[Put("/api/User/{request.Id}")]
		Task<UserDto> Update([Body]UpdateUserRequest request);
		
		[Delete("/api/User/{request.Id}")]
		Task Delete(DeleteUserRequest request);
	
	}

}
