using Domain.Core.User.Contracts.AppServices;
using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.User
{
    public class AppUserAppService : IAppUserAppService
    {
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<AppUserAppService> _logger;
        public AppUserAppService(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AppUserAppService> logger)
        {
            _signinManager = signInManager;
            _userManager = userManager;
            _contextAccessor = httpContextAccessor;
            _logger = logger;
        }
        public async Task<int>? LoggedInUserId()
        {
            var userName = _contextAccessor.HttpContext.User.Identity.Name;
            if(userName != null )
            {
                _logger.LogInformation("user logged in");
            }
            else
            {
                _logger.LogError("user is not logged in");
            }
            var user = await _userManager.FindByNameAsync(userName);
            var id = user.Id;
            return id;
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _userManager.Users
                .Include(x => x.Customer)
                .Include(k => k.Expert)
                .Include(u => u.Admin)
                .FirstOrDefaultAsync(k => k.Email == email);
            var result = await _signinManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<List<IdentityError>> Register(string email, string password, string fullname, string phonenumber, bool IsCustomer, bool IsExpert,bool isAdmin)
        {
            var role = string.Empty;
            var user = CreateUser();

            user.UserName = email;
            user.Email = email;
            if (IsCustomer)
            {
                role = "Customer";
                user.Customer = new Customer
                {
                    Email = email,
                    Password = password,
                    FullName = fullname,
                    PhoneNumber = phonenumber
                };

            }

            if (IsExpert)
            {
                role = "Expert";
                user.Expert = new Expert
                {
                    FullName = fullname,
                    Email = email,
                    Password = password,
                    PhoneNumber = phonenumber
                };
            }

            if (isAdmin)
            {
                role = "Admin";
                user.Admin = new Admin
                {
                    FullName = fullname,
                    Email = email,
                    Password = password,
                    PhoneNumber = phonenumber
                };
            }

            var result = await _userManager.CreateAsync(user, password);
            if (IsCustomer)
            {
                var userIdCustomer = user.Customer!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userIdCustomer", userIdCustomer.ToString()));
            }
            if (IsExpert)
            {
                var userIdExpert = user.Expert!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userIdExpert", userIdExpert.ToString()));
            }
            if (isAdmin)
            {
                var userIdAdmin = user.Admin!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userIdAdmin", userIdAdmin.ToString()));
            }

            if (result.Succeeded) await _userManager.AddToRoleAsync(user, role);
            return (List<IdentityError>)result.Errors;
        }

        public async Task SignOutUser()
        {
            await _signinManager.SignOutAsync();
        }

        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                                                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

    }
}
