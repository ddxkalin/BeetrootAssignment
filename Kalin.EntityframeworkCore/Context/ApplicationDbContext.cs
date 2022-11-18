using Kalin.EntityframeworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Kalin.EntityframeworkCore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
}
