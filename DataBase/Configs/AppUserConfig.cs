using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Configs
{
    public static class AppUserConfig
    {
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            //var hasher = new PasswordHasher<AppUser>();

            //// users:
            //var users = new List<AppUser>()
            //{
            //    new AppUser()
            //    {
            //        Id = 1,
            //        UserName = "zolghadrisahin@ymail.com",
            //        NormalizedEmail = "ZOLGHADRISAHIN@YMAIL.COM",
            //        Email = "zolghadrisahin@ymail.com",
            //        NormalizedUserName = "ZOLGHADRISAHIN@YMAIL.COM",
            //        LockoutEnabled = false,
            //        PhoneNumber = "09193017184",
            //        SecurityStamp = Guid.NewGuid().ToString(),
            //    },
            //    new AppUser()
            //    {
            //        Id = 2,
            //        UserName = "shakibzolghadri@gmail.com",
            //        Email = "shakibzolghadri@gmail.com",
            //        NormalizedEmail = "SHAKIBZOLGHADRI@GMAIL.COM",
            //        NormalizedUserName = "SHAKIBZOLGHADRI@GMAIL.COM",
            //        LockoutEnabled = false,
            //        PhoneNumber = "09106265176",
            //        SecurityStamp = Guid.NewGuid().ToString()
            //    },
            //    new AppUser()
            //    {
            //        Id = 3,
            //        UserName = "amirfarshad@gmail.com",
            //        Email = "amirfarshad@gmail.com",
            //        NormalizedEmail = "AMIRFARSHAD@GMAIL.COM",
            //        NormalizedUserName = "AMIRFARSHAD@GMAIL.COM",
            //        LockoutEnabled = false,
            //        PhoneNumber = "09125254199",
            //        SecurityStamp = Guid.NewGuid().ToString()
            //    },
            //    new AppUser()
            //    {
            //        Id = 4,
            //        UserName = "arshiahp@gmail.com",
            //        Email = "arshiahp@gmail.com",
            //        NormalizedEmail = "ARSHIAHP@GMAIL.COM",
            //        NormalizedUserName = "ARSHIAHP@GMAIL.COM",
            //        LockoutEnabled = false,
            //        PhoneNumber = "09331476832",
            //        SecurityStamp = Guid.NewGuid().ToString()
            //    },
            //    new AppUser()
            //    {
            //        Id = 5,
            //        UserName = "sadradn@gmail.com",
            //        Email = "sadradn@gmail.com",
            //        NormalizedUserName = "SADRADN@GMAIL.COM",
            //        NormalizedEmail = "SADRADN@GMAIL.COM",
            //        LockoutEnabled = false,
            //        PhoneNumber = "09127518144",
            //        SecurityStamp = Guid.NewGuid().ToString()
            //    },
            //    new AppUser()
            //    {
            //        Id = 6,
            //        UserName = "soheilj@gmail.com",
            //        Email = "soheilj@gmail.com",
            //        NormalizedEmail = "SOHEILJ@GMAIL.COM",
            //        NormalizedUserName = "SOHEILJ@GMAIL.COM",
            //        LockoutEnabled = false,
            //        PhoneNumber = "09104029183",
            //        SecurityStamp = Guid.NewGuid().ToString()
            //    }
            //};

            //foreach (var user in users)
            //{
            //    var passwordhasher = new PasswordHasher<AppUser>();
            //    user.PasswordHash = passwordhasher.HashPassword(user, "sh19451960");

            //    modelBuilder.Entity<AppUser>().HasData();
            //}

            // roles
            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole<int>() { Id = 3, Name = "Expert", NormalizedName = "EXPERT" }
                );

            // roles to users
            //modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            //    new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
            //    new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
            //    new IdentityUserRole<int>() { RoleId = 2, UserId = 3 },
            //    new IdentityUserRole<int>() { RoleId = 2, UserId = 4 },
            //    new IdentityUserRole<int>() { RoleId = 3, UserId = 5 },
            //    new IdentityUserRole<int>() { RoleId = 3, UserId = 6 }
            //    );
        }
    }
}
