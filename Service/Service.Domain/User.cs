using Cybtans.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Domain
{
    [GenerateMessage(Service = ServiceType.Partial)]
    public class User: DomainEntity<int>, ISoftDelete
    {        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PrimaryPhone { get; set; }

        public string SecundaryPhone { get; set; }

        public Address Address { get; set; }

        public bool IsDeleted { get; set; }

        public Dictionary<string, string> Settings { get; set; }
      
        [MessageExcluded]
        public ICollection<UserFollowings> Followings { get; set; } = new HashSet<UserFollowings>();

        [MessageExcluded]
        public ICollection<UserFollowings> FollowedBy { get; set; } = new HashSet<UserFollowings>();
    }
}
