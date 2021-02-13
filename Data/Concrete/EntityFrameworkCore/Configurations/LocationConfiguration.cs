using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFrameworkCore.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Source).HasMaxLength(300);
            builder.Property(a => a.Source).IsRequired(true);

            builder.Property(a => a.Target).HasMaxLength(300);
            builder.Property(a => a.Target).IsRequired(true);

            builder.HasMany(a => a.Voyages).WithOne(a => a.Location).HasForeignKey(a => a.LocationId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Location[]
            {
                new Location(){Id=1,Source="Ankara",Target="İzmir", StandartPrice=100},
                new Location(){Id=2,Source="Hatay",Target="İstanbul",StandartPrice=130},
                new Location(){Id=3,Source="İstanbul",Target="Hatay",StandartPrice=130}
            });
        }
    }
}
