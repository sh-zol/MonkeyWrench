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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
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
                .WithOne(x => x.Customer);

            // seed 
            builder.HasData(new List<Customer>
            {
                new Customer { Id = 1,
                FullName = "شکیب ذوالقدری",
                Email = "shakibzolghadri@gmail.com",
                Password = "sh19451960",
                PhoneNumber = "09106265176",
                Address = "تهران",
                AboutMe = "مشتری هستم",
                AppUserId = 2
            },
                new Customer
                {
                    Id = 2,
                    FullName = "امیر فرشاد",
                    Email = "amirfarshad@gmail.com",
                    Password = "sh19451960",
                    PhoneNumber = "09125254199",
                    AppUserId = 3
                },
                new Customer
                {
                    Id = 3,
                    FullName = "عرشیا حسن‌پور",
                    Email = "arshiahp@gmail.com",
                    Password = "sh19451960",
                    PhoneNumber = "09331476832",
                    AppUserId = 4
                }
            });
        }
    }
}
