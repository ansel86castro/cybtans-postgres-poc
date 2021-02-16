using AutoMapper;
using Cybtans.Entities;
using Cybtans.Services;
using Cybtans.Services.Extensions;
using Microsoft.Extensions.Logging;
using Service.Domain;
using Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    partial class UserService :IUserService
    {
        private readonly IRepository<UserFollowings> _followingRepository;

        public UserService(IRepository<User, int> repository, IRepository<UserFollowings> followingRepository, IUnitOfWork uow, IMapper mapper, ILogger<UserService> logger)
        : base(repository, uow, mapper, logger)
        {
            _followingRepository = followingRepository;
        }

        public async Task<GetAllUserResponse> GetFollowed(GetUserFollowingRequest request)
        {
            var query = Repository.Where(x => x.Id == request.Id).SelectMany(x => x.FollowedBy).Select(x => x.Follower);

            var page = await query.PageBy(request.Filter, request.Sort, request.Skip, request.Take);
            return new GetAllUserResponse
            {
                Items = await Mapper.ProjectTo<UserDto>(page.Query).ToListAsync(),
                TotalCount = page.TotalCount,
                Page = page.Page,
                TotalPages = page.TotalPages
            };
        }

        public async Task<GetAllUserResponse> GetFollowing(GetUserFollowingRequest request)
        {
            var query = Repository.Where(x => x.Id == request.Id).SelectMany(x => x.Followings).Select(x=>x.Following);

            var page = await query.PageBy(request.Filter, request.Sort, request.Skip, request.Take);
            return new GetAllUserResponse
            {
                Items = await Mapper.ProjectTo<UserDto>(page.Query).ToListAsync(),
                TotalCount = page.TotalCount,
                Page = page.Page,
                TotalPages = page.TotalPages
            };
        }

        public async Task<UserDto> AddFollowing(AddFollowingRequest request)
        {            
            var user = await Repository.Get(request.Id) ?? throw new EntityNotFoundException("Follower user not found");
            var following = await Repository.Get(request.FollowingId) ?? throw new EntityNotFoundException("User to follow not found");

            if (user.Id == following.Id)
                throw new ValidationException("User can not follow itself");

            if (await _followingRepository.Where(x => x.FollowerId == request.Id && x.FollowingId == request.FollowingId).CountAsync() > 0)
                throw new ValidationException($"User {request.Id} aldready follows {request.FollowingId}");

            user.Followings.Add(new UserFollowings
            {
                Following = following
            });

            await Repository.SaveChanges();

            return await Get(request.FollowingId);
        }

        public async Task RemoveFollowing(UnFollowingRequest request)
        {
            var user = await Repository.Get(request.Id) ?? throw new EntityNotFoundException("Follower user not found");
            var following = await Repository.Get(request.FollowingId) ?? throw new EntityNotFoundException("User to follow not found");

            if (user.Id == following.Id)
                throw new ValidationException("User can not follow itself");

            if (await _followingRepository.Where(x => x.FollowerId == request.Id && x.FollowingId == request.FollowingId).CountAsync() == 0)
                throw new ValidationException($"User {request.Id} does not follows {request.FollowingId}");

            _followingRepository.Remove(new UserFollowings
            {
                FollowerId = request.Id,
                FollowingId = request.FollowingId
            });

            await _followingRepository.SaveChanges();
            
        }
    }
}
