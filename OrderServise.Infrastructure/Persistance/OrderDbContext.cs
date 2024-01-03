using Microsoft.EntityFrameworkCore;
using OrderServise.Domain.Entities;
using OrderServise.Infrastructure.Persistance.EFConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.Persistance
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Actor>  Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ActorMovie>  ActorMovie { get; set; }
        public DbSet<GenreMovie> GenreMovie { get; set; }
        public DbSet<MovieTheater> MovieTheater { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEfConfiguration());
            modelBuilder.HasDefaultSchema("ordering");
            modelBuilder.Entity<ActorMovie>().HasKey(p => new { p.MovieId, p.ActorId });
            modelBuilder.Entity<GenreMovie>().HasKey(p=>new {p.MovieId,p.GenreId});
            modelBuilder.Entity<MovieTheater>().HasKey(p => new { p.MovieId, p.TheaterId });
        }
    }
}
