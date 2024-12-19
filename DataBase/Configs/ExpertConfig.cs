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
    public class ExpertConfig : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
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
                .WithOne(x => x.Expert);

            // seed 
            builder.HasData(new List<Expert>
            {
                new Expert
                {
                    Id = 1,
                    FullName = "صدرا دویران",
                    Email = "sadradn@gmail.com",
                    Password = "sh19451960",
                    PhoneNumber = "09127518144",
                    AppUserId = 5

                },
                new Expert
                {
                    Id = 2,
                    FullName = "سهیل جیبویی",
                    Email = "soheilj@gmail.com",
                    Password = "sh19451960",
                    PhoneNumber = "09104029183",
                    AppUserId = 6
                }
            });
        }
    }
}
