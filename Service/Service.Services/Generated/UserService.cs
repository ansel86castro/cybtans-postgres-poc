
using System;
using AutoMapper;
using Cybtans.Entities;
using Cybtans.Services;
using Microsoft.Extensions.Logging;
using Service.Domain;
using Service.Models;

namespace Service.Services
{
    [RegisterDependency(typeof(IUserService))]
    public partial class UserService : CrudService<User, int, UserDto, GetUserRequest, GetAllRequest, GetAllUserResponse, UpdateUserRequest, CreateUserRequest, DeleteUserRequest>, IUserService
    {
        
    }
}