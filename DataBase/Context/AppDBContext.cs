using DataBase.Configs;
using Domain.Core.HomeService.Entities;
using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Context
{
    public class AppDBContext:IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ExpertSkill> ExpertSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new AdminConfig());
            builder.ApplyConfiguration(new CustomerConfig());
            builder.ApplyConfiguration(new ExpertConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new ServiceConfig());
            builder.ApplyConfiguration(new RequestConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new BidConfig());
            builder.ApplyConfiguration(new StatusConfig());
            builder.ApplyConfiguration(new ExpertSkillConfig());

            AppUserConfig.SeedRoles(builder);

            base.OnModelCreating(builder);

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}
    }
}
