using System;
using System.Threading.Tasks;
using Service.Models;
using System.Collections.Generic;

namespace Service.Services
{
	public partial interface IUserService 
	{
		
		Task<GetAllUserResponse> GetFollowing(GetUserFollowingRequest request);
		
		
		Task<GetAllUserResponse> GetFollowed(GetUserFollowingRequest request);
		
		
		Task<UserDto> AddFollowing(AddFollowingRequest request);
		
		
		Task RemoveFollowing(UnFollowingRequest request);
		
		
		Task<GetAllUserResponse> GetAll(GetAllRequest request);
		
		
		Task<UserDto> Get(GetUserRequest request);
		
		
		Task<UserDto> Create(CreateUserRequest request);
		
		
		Task<UserDto> Update(UpdateUserRequest request);
		
		
		Task Delete(DeleteUserRequest request);
		
	}

}
