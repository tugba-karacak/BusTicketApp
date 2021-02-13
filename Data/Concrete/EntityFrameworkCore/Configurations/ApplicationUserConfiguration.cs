using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFrameworkCore.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(200);
            builder.Property(a => a.Name).IsRequired(true);

            builder.Property(a => a.Surname).HasMaxLength(200);
            builder.Property(a => a.Surname).IsRequired(true);

            builder.Property(a => a.Password).HasMaxLength(200);
            builder.Property(a => a.Password).IsRequired(true);

            builder.Property(a => a.Email).HasMaxLength(200);
            builder.Property(a => a.Email).IsRequired(true);

            builder.HasOne(a => a.Role).WithMany(a => a.ApplicationUsers).HasForeignKey(a => a.RoleId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new ApplicationUser[]
            {
                new ApplicationUser{ Id=1,Email="admin@mail.com",Name="Tuğba",Surname="Karacak",Password="1",RoleId=1},
                  new ApplicationUser{ Id=2,Email="member@mail.com",Name="Ayşe",Surname="Çetinkaya",Password="1",RoleId=2}
            });

        }
    }
}
