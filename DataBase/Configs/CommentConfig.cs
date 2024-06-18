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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Comments);
            builder.HasOne(x => x.Request)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Service)
                .WithMany(x => x.Comments);
        }
    }
}
