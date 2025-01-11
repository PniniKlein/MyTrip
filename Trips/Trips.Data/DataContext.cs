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
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}