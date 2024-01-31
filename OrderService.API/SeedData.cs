using AutoMapper;
using OrderServise.Domain.Entities;
using OrderServise.Infrastructure.Persistance;

namespace OrderService.API
{
    public static class SeedData
    {
        public static void SeedAppData(IApplicationBuilder app)
        {
          using(var serviceScope=app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
            var context =serviceScope.ServiceProvider.GetRequiredService<OrderDbContext>();
               if( context.Actors.Count()==0)
                {
                    context.AddRange(Actors());
                    context.SaveChanges();

                }
            }
        }
        public static async Task SeedDataLast(OrderDbContext context)
        {
            if (context.Actors.Count() == 0)
            {
                context.AddRange(Actors());
              await  context.SaveChangesAsync();

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
