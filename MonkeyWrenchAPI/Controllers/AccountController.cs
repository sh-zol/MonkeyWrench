using Domain.Core.User.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonkeyWrenchAPI.Models;

namespace MonkeyWrenchAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserAppService _appuser;

        public AccountController(IAppUserAppService appuser)
        {
            _appuser = appuser;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _appuser.Register(registerVM.Email, registerVM.Password, registerVM.FullName, registerVM.PhoneNumber, registerVM.IsCustomer, registerVM.IsExpert, registerVM.IsAdmin);
                if (result.Count == 0)
                {
                    return Ok();
                }
                else
                {
                    foreach (var item in result)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return Ok();
        }

    }
}
