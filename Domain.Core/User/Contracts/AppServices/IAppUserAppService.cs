using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Contracts.AppServices
{
    public interface IAppUserAppService
    {
        Task<List<IdentityError>> Register(string email, string password, string fullname, string phonenumber, bool IsCustomer, bool IsExpert,bool isAdmin);
        Task<bool> Login(string email, string password);
        Task SignOutUser();
        Task<int>? LoggedInUserId();
    }
}
