using Domain.Core.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Configs
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.AboutMe)
                .HasMaxLength(400);
            builder.Property(x => x.Address)
                .HasMaxLength(350);
            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12);
            builder.HasOne(x => x.AppUser)
                .WithOne(x => x.Admin);

            //seed
            builder.HasData(new List<Admin>
            {
                new Admin {
                    Id = 1,
                    FullName = "شاهین ذوالقدری",
                    Email = "zolghadrisahin@ymail.com",
                    Password = "sh19451960",
                    PhoneNumber = "09193017184",
                    Address="Tehran marzdaran",
                    AboutMe = "i'm admin",
                    AppUserId = 1
                }
            });
        }
    }
}
