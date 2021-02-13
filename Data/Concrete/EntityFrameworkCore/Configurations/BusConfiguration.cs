using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EntityFrameworkCore.Configurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(300);
            builder.Property(a => a.Name).IsRequired(true);

            builder.HasData(new Bus[]
            {
                new Bus{Id=1, Name="Tuğba Turizm"},
                new Bus{Id=2, Name="Ayşe Turizm"}
            });
        }
    }
}
