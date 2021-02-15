using Cybtans.Entities;

namespace Service.Domain
{
    [GenerateMessage(Service = ServiceType.Default)]
    public class OrderState : Entity<int>
    {
        public string Name { get; set; }
    }
}
