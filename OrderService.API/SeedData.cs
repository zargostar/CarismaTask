using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OrderServise.Domain.Common;
using OrderServise.Domain.Entities;
using OrderServise.Infrastructure.Persistance;

namespace OrderService.API
{
    public static class SeedData
    {
        public static async Task SeedUserAppData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                if (context.Users.Count() == 0)
                {
                    var defaultUser = new AppUser()
                    {
                        FirstName = "admin",
                        LastName = "admin",
                        UserName = "admin",

                    };
                 
                    var defaulRoles = new List<IdentityRole>() {
                    new IdentityRole()
                    {
                        Name = UserRole.ADMIN,

                    },
                    new IdentityRole()
                    {
                        Name = UserRole.CUSTOMER,

                    },
                    new IdentityRole()
                    {
                        Name = UserRole.OPERATOR,

                    },
                    };
                    var roleContext = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    foreach (var role in defaulRoles) {
                       await roleContext.CreateAsync(role);
                    }
                    var userRolesList = defaulRoles.Select(role => role.Name).ToList();
                    await context.CreateAsync(defaultUser, "Mm@09133689050");
                    if(userRolesList is not null)
                    {
                        await context.AddToRolesAsync(defaultUser, userRolesList);
                    }
                   

                }
            }
        }
        public static async Task SeedDataLast(DataBaseContext context)
        {
            if (context.Actors.Count() == 0)
            {
                context.AddRange(Actors());
                await context.SaveChangesAsync();

            }

        }
        private static List<Actor> Actors()
        {
            var actors = new List<Actor>()
            {
                new Actor()
                {
                    Name="Majid",

                },
                new Actor()
                {
                    Name="hasan"
                }
            };
            return actors;

        }
    }

}
