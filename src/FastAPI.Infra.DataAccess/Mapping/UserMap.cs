using FastAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastAPI.Infra.DataAccess.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x=> x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Password).HasMaxLength(256).IsRequired();

        }
    }
}
