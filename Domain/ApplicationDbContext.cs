using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt):
            base(opt)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=localhost;Database=UDP_Client;Username=postgres;Password=9316");


        public DbSet<Client> Clients { get; set; }

        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

