using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EntityFrameworkCore.Configurations
{
    public class VoyageConfiguration : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Location).WithMany(a => a.Voyages).HasForeignKey(a => a.LocationId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Bus).WithMany(a => a.Voyages).HasForeignKey(a => a.BusId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Voyage[]
            {
                new Voyage
                {Id=1,LocationId=1,BusId=1,VoyageDate=new DateTime(2021,02,15,20,15,0)},
                new Voyage{Id=2,LocationId=2,BusId=2,VoyageDate=new DateTime(2021,02,15,6,30,0)},
                new Voyage{Id=3,LocationId=3,BusId=1,VoyageDate=new DateTime(2021,02,16,20,15,0)}
            });
        }
    }
}
