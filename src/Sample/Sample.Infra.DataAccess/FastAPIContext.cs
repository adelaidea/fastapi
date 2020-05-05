using Microsoft.EntityFrameworkCore;
using Sample.Domain.Administration.Users;
using Sample.Infra.DataAccess.Mapping;
using System;

namespace Sample.Infra.DataAccess
{
    public class FastAPIContext : DbContext
    {
        public FastAPIContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMapping());
        }
    }
}
