
using FastAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FastAPI.Infra.DataAccess
{
    public class FastAPIContext : DbContext
    {
        public FastAPIContext(DbContextOptions options)
            : base(options)
        {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(FastAPIContext).Assembly);            
        }


        protected virtual void SetupEntityConfiguration(Type type)
        {

        }

    }
}
