using Cybtans.Entities;
using System;

namespace Service.Domain
{
    [GenerateMessage]

    public class UserFollowings:DomainEntity
    {
        public int FollowerId { get; set; }

        public int FollowingId { get; set; }

        public User Follower { get; set; }

        public User Following { get; set; }
    }   
}
