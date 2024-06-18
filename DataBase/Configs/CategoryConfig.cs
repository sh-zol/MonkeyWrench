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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(40);
            builder.HasMany(x => x.Services)
                .WithOne(x => x.Category);

            // seed
            builder.HasData(new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Title = "کولر آبی",
                    IsActive = true
                },
                new Category
                {
                    Id = 2,
                    Title = "کولر گازی",
                    IsActive = true
                },
                new Category
                {
                    Id = 3,
                    Title = "کامپیوتر و سخت افزار",
                    IsActive = true
                },
                new Category
                {
                    Id = 4,
                    Title = "وسایل نمایشی",
                    IsActive = true
                },
                new Category
                {
                    Id = 5,
                    Title = "وسایل آشپزخانه",
                    IsActive = true
                },
                new Category
                {
                    Id = 6,
                    Title = "مکانیک",
                    IsActive = true
                },
                new Category
                {
                    Id = 7,
                    Title = "ساختمان",
                    IsActive = true
                } });
        }
    }
}
