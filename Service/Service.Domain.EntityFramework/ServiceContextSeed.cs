using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cybtans.AspNetCore.Migrations;
using Cybtans.Entities;

namespace Service.Domain.EntityFramework
{
    public class ServiceContextSeed : IDbContextSeed<ServiceContext>
    {
        public async Task Seed(ServiceContext context)
        {                         
            if (!context.Users.Any())
            {
                context.Users.AddRange(Enumerable.Range(1, 10).Select(i => new User
                {
                    FirstName = $"User {i} FirstName",
                    LastName = $"User {i} Lastname",
                    Email = $"user{i}@test.com",
                    Address = new Address { City = "string", Country = "string", Number = "string", State = "string", Street = "string" },
                    Creator = "admin",
                    CreateDate = DateTime.Now,
                    PrimaryPhone = "1111111",                     
                    Settings = new Dictionary<string, string>
                    {
                        ["AppSetting1"] = "Setting1",
                        ["AppSetting2"] = "Setting2",
                        ["AppSetting3"] = "Setting3",
                    }
                }));

                await context.SaveChangesAsync();

                foreach (var user in await context.Users.Take(2).ToListAsync())
                {
                    foreach (var item in context.Users.Where(x => x.Id != user.Id).Take(5).Select(x => new UserFollowings { Following = x }))
                    {
                        user.Followings.Add(item);
                    }
                }
                               
                await context.SaveChangesAsync();
            }
        }
    }
}
