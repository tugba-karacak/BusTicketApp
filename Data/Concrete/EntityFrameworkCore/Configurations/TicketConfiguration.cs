using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EntityFrameworkCore.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasIndex(a => new { a.VoyageId, a.SeatNumber }).IsUnique(true);

            builder.Property(a => a.Name).HasMaxLength(200);
            builder.Property(a => a.Name).IsRequired(true);

            builder.Property(a => a.Surname).HasMaxLength(200);
            builder.Property(a => a.Surname).IsRequired(true);

            builder.HasOne(a => a.Voyage).WithMany(a => a.Tickets).HasForeignKey(a => a.VoyageId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
