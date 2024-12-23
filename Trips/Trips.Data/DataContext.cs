using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Text.Json;
using Trips.Core.Entities;

namespace Trips.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Attraction> attractions { get; set; }
        public DbSet<Guide> guides { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<User> users { get; set; }

        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}