using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFrameworkCore.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired(true);

            builder.HasData(new Role[]
            {
                new Role{Id=1,Name="Admin"},
                new Role{Id=2,Name="Member"}
            });
        }
    }
}
