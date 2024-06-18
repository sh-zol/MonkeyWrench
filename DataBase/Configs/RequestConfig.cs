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
    public class RequestConfig : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(350);
            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.DeadLine);
            builder.HasOne(x => x.Service)
                .WithMany(x => x.Requests);
            builder.HasOne(x => x.Status)
                .WithOne(x => x.Request)
                .HasForeignKey<Status>(x=>x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Customer)
                .WithMany(x=>x.Requests);
            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Requests);
        }
    }
}
