using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.HomeService.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace MonkeyWrenchAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly ICategoryAppService _category;
        private readonly IServiceAppService _service;
        private readonly IRequestAppService _request;

        public ListController(IRequestAppService request,
            IServiceAppService serviceAppService,
            ICategoryAppService categoryAppService)
        {
            _request = request;
            _service = serviceAppService;
            _category = categoryAppService;
        }


        [HttpGet]
        [Route("CategoryList")]
        public async Task<List<CategoryDTO>> CategoryList(CancellationToken cancellationToken)
        {
            return await _category.GetAll(cancellationToken);
        }

        [HttpGet]
        [Route("ServiceList")]
        public async Task<List<ServiceDTO>> ServiceList(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        [HttpGet]
        [Route("RequestList")]
        public async Task<List<RequestDTO>> RequestList(CancellationToken cancellationToken)
        {
            return await _request.GetAll(cancellationToken);
        }
    }
}
