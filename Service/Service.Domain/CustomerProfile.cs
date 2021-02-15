using Cybtans.Entities;
using System;

namespace Service.Domain
{
    [GenerateMessage]
    public class CustomerProfile : DomainTenantEntity<Guid>
    {
        public string Name { get; set; }
    }
}
