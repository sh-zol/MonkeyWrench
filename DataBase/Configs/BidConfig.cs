using Domain.Core.HomeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Configs
{
    public class BidConfig : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Price)
                .IsRequired()
                .HasMaxLength(12);
            builder.Property(x=>x.DeadLine)
                .IsRequired();
            builder.Property(x => x.CreatedAt);

            // relations
            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Bids);
            builder.HasOne(x => x.Request)
                .WithMany(x => x.Bids)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
