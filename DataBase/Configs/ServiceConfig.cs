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
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Description)
                .HasMaxLength(200);

            //seed
            builder.HasData(new List<Service>
            {
                new Service
                {
                    Id = 1,
                    Title = "راه اندازی کولر آبی",
                    CategoryId = 1,
                    IsActive = true,
                },
                new Service
                {
                    Id = 2,
                    Title = "تعمیرات کولر آبی",
                    CategoryId = 1,
                    IsActive = true
                },
                new Service
                {
                    Id = 3,
                    Title = "تعمیرات کولر گازی",
                    CategoryId = 2,
                    IsActive = true
                },
                new Service
                {
                    Id = 4,
                    Title = "راه اندازی کولر گازی",
                    CategoryId = 2,
                    IsActive = true
                },
                new Service
                {
                    Id = 5,
                    Title = "تعمیر کیس",
                    CategoryId = 3,
                    IsActive = true
                },
                new Service
                {
                    Id = 6,
                    Title = "تعمیر مادربرد و بایوس",
                    CategoryId = 3,
                    IsActive = true
                },
                new Service
                {
                    Id = 7,
                    Title = "تعمیر تلویزیون",
                    CategoryId = 4,
                    IsActive = true
                },
                new Service
                {
                    Id = 8,
                    Title = "تعمیر مانیتور",
                    CategoryId = 4,
                    IsActive = true
                },
                new Service
                {
                    Id = 9,
                    Title = "تعمیر یخچال",
                    CategoryId = 5,
                    IsActive = true
                },
                new Service
                {
                    Id = 10,
                    Title = "تعمیر اجاق و فر",
                    CategoryId = 5,
                    IsActive = true
                },
                new Service
                {
                    Id = 11,
                    Title = "تعمیر ماشین لباسشویی",
                    CategoryId = 5,
                    IsActive = true
                },
                new Service
                {
                    Id = 12,
                    Title = "تعمیر ماشین ظرف‌شویی",
                    CategoryId = 5,
                    IsActive = true
                },
                new Service
                {
                    Id = 13,
                    Title = "تعمیر موتور خودرو",
                    CategoryId = 6,
                    IsActive = true
                },
                new Service
                {
                    Id = 14,
                    Title = "تعمیر موتور سیکلت",
                    CategoryId = 6,
                    IsActive = true
                },
                new Service
                {
                    Id = 15,
                    Title = "تعویض روغن موتور",
                    CategoryId = 6,
                    IsActive = true
                },
                new Service
                {
                    Id = 16,
                    Title = "سیم‌کشی ساختمان",
                    CategoryId = 7,
                    IsActive = true
                },
                new Service
                {
                    Id = 17,
                    Title = "لوله کشی ساختمان",
                    CategoryId = 7,
                    IsActive = true
                }
            });
        }
    }
}
