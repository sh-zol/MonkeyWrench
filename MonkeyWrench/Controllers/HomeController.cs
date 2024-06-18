using Domain.Core.HomeService.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonkeyWrench.Models;
using System.Diagnostics;

namespace MonkeyWrench.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAppService _category;
        private readonly IServiceAppService _service;

        public HomeController(ILogger<HomeController> logger, IServiceAppService service,ICategoryAppService categoryAppService)
        {
            _logger = logger;
            _service = service;
            _category = categoryAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList(CancellationToken cancellationToken)
        {
            var list = await _category.GetAll(cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> ShowCategoryServices(int categoryId,CancellationToken cancellationToken)
        {
            var list = await _service.GetByCategoryId(categoryId, cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList(CancellationToken cancellationToken)
        {
            var list = await _service.GetAll(cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> ServiceDetails(int serviceId,CancellationToken cancellationToken)
        {
            var service = await _service.GetByServiceId(serviceId, cancellationToken);
            return View(service);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
