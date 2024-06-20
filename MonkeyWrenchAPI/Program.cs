
using AppServices.HomeService;
using AppServices.User;
using DataAccess.HomeService;
using DataAccess.User;
using DataBase.Context;
using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.HomeService.Contracts.Repositories;
using Domain.Core.HomeService.Contracts.Services;
using Domain.Core.Sitesettings;
using Domain.Core.User.Contracts.AppServices;
using Domain.Core.User.Contracts.Repositories;
using Domain.Core.User.Contracts.Services;
using Domain.Core.User.Entities;
using FrameWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Services.HomeService;
using Services.User;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

namespace MonkeyWrenchAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Repositories
            builder.Services.AddScoped<IBidRepo, BidRepo>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ICommentRepo, CommentRepo>();
            builder.Services.AddScoped<IRequestRepo, RequestRepo>();
            builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
            builder.Services.AddScoped<IPersonRepo, PersonRepo>();
            builder.Services.AddScoped<IStatusRepo, StatusRepo>();
            #endregion

            #region Services
            builder.Services.AddScoped<IBidService, BidService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IStatusService, StatusService>();
            #endregion

            #region AppServices
            builder.Services.AddScoped<IBidAppService, BidAppService>();
            builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
            builder.Services.AddScoped<ICommentAppService, CommentAppService>();
            builder.Services.AddScoped<IRequestAppService, RequestAppService>();
            builder.Services.AddScoped<IServiceAppService, ServiceAppService>();
            builder.Services.AddScoped<IAppUserAppService, AppUserAppService>();
            builder.Services.AddScoped<IPersonAppService, PersonAppService>();
            builder.Services.AddScoped<IStatusAppService, StatusAppService>();
            #endregion

            #region Configuration 
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var sitesettings = config.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            builder.Services.AddSingleton(sitesettings);
            #endregion

            #region EF Configuration
            builder.Services.AddDbContext<AppDBContext>(o => o.UseSqlServer(sitesettings.SqlConfig.ConnectionString));
            #endregion

            #region Identity Configuration
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>(o =>
            {
                o.SignIn.RequireConfirmedAccount = false;
                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 6;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            }
            ).AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDBContext>()
            .AddErrorDescriber<PersianIdentityErrorDescriber>();
            #endregion

            #region Log Config
            builder.Logging.ClearProviders();
            builder.Host.ConfigureLogging(loggingbuilder =>
            {
                loggingbuilder.ClearProviders();
            }).UseSerilog((context, config) =>
            {
                config.WriteTo.Seq("http://localhost:5341", Serilog.Events.LogEventLevel.Information);
            });
            #endregion

            #region Json Configuration

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            #endregion
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCors(Option =>
            {
                Option.AllowAnyMethod();
                Option.AllowAnyHeader();
                Option.AllowAnyOrigin();
            });
            app.UseRouting();
            app.Run();
        }
    }
}
