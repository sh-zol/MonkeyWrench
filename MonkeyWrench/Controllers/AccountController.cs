using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.User.Contracts.AppServices;
using Domain.Core.User.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonkeyWrench.Models.VMs;

namespace MonkeyWrench.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserAppService _appuser;
        private readonly IPersonAppService _person;
        private readonly IServiceAppService _service;
        public AccountController(IAppUserAppService appuser,
            IPersonAppService personAppService,
            IServiceAppService serviceAppService)
        {
            _appuser = appuser;
            _person = personAppService;
            _service = serviceAppService;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _appuser.Register(registerVM.Email, registerVM.Password, registerVM.FullName, registerVM.PhoneNumber, registerVM.IsCustomer, registerVM.IsExpert,registerVM.IsAdmin);
                if(result.Count == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var item in result)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _appuser.Login(loginVM.Email, loginVM.Password);
                if(result == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "رمز عبور یا نام کاربری اشتباه است");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _appuser.SignOutUser();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UpdateProfileAdmin(CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            ViewBag.Id = loggedIn;
            var user = await _person.GetAdmin(loggedIn, cancellationToken);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateProfileAdmin(AdminDTO admin,IFormFile file,CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            var adminToFind = await _person.GetAdmin(loggedIn, cancellationToken);
            var user = new AdminDTO
            {
                Id = adminToFind.Id,
                FullName = admin.FullName,
                Email = admin.Email,
                Password = admin.Password,
                PhoneNumber = admin.PhoneNumber,
                AboutMe = admin.AboutMe,
                Address = admin.Address,
                FileLocation = admin.FileLocation,
            };
            await _person.UpdateAdminProfile(user, file, cancellationToken);
            return RedirectToAction("Index", "Admin");
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> UpdateProfileCustomer(CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            ViewBag.Id = loggedIn;
            var customer = await _person.GetCustomer(loggedIn, cancellationToken);
            return View(customer);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> UpdateProfileCustomer(CustomerDTO customer,IFormFile file,CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            var customerToFind = await _person.GetCustomer(loggedIn, cancellationToken);
            var user = new CustomerDTO
            {
                Id = customerToFind.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
                AboutMe = customer.AboutMe,
                Address = customer.Address,
                FileLocation = customer.FileLocation,
            };
            await _person.UpdateCustomerProfile(user, file, cancellationToken);
            return RedirectToAction("Index","Customer");
        }

        [Authorize(Roles = "Expert")]
        [HttpGet]
        public async Task<IActionResult> UpdateProfileExpert(CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            ViewBag.Id = loggedIn;
            var user = await _person.GetExpert(loggedIn, cancellationToken);
            return View(user);
        }

        [Authorize(Roles = "Expert")]
        [HttpPost]
        public async Task<IActionResult> UpdateProfileExpert(ExpertDTO expert,IFormFile file,CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            var expertToFind = await _person.GetExpert(loggedIn,cancellationToken);
            var user = new ExpertDTO
            {
                Id = expertToFind.Id,
                FullName = expert.FullName,
                Email = expert.Email,
                Password = expert.Password,
                PhoneNumber = expert.PhoneNumber,
                AboutMe = expert.AboutMe,
                Address = expert.Address,
                FileLocation = expert.FileLocation,
            };
            await _person.UpdateExpertProfile(user, file, cancellationToken);
            return RedirectToAction("Index", "Expert");
        }

        [Authorize(Roles = "Expert")]
        [HttpGet]
        public async Task<IActionResult> UpdateExpertSkills(CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(loggedIn, cancellationToken);
            ViewBag.expertId = expert.Id;
            var services = await _service.GetAll(cancellationToken);
            ViewBag.Services = services.Where(x => !expert.Services.Any(y => y.Title == x.Title))
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToList();
            var expertServices = expert.Services;
            return View(expertServices);
        }

        [Authorize(Roles = "Expert")]
        [HttpPost]
        public async Task<IActionResult> UpdateExpertSkills(int expertId,List<int> services,CancellationToken cancellationToken)
        {
            var loggedIn = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(loggedIn, cancellationToken);
            await _person.UpdateExpertSkills(expert.Id, services, cancellationToken);
            return RedirectToAction("Index", "Expert");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
