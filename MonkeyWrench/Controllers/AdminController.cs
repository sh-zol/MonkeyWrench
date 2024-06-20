using AppServices.User;
using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.HomeService.DTOS;
using Domain.Core.User.Contracts.AppServices;
using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MonkeyWrench.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryAppService _category;
        private readonly IServiceAppService _service;
        private readonly IBidAppService _bid;
        private readonly ICommentAppService _comment;
        private readonly IRequestAppService _request;
        private readonly IStatusAppService _status;
        private readonly IPersonAppService _person;
        private readonly IAppUserAppService _appuser;

        public AdminController(ICategoryAppService category,
            IServiceAppService serviceAppService,
            IBidAppService bidAppService,
            ICommentAppService commentAppService,
            IRequestAppService requestAppService,
            IStatusAppService statusAppService,
            IPersonAppService personAppService,
            IAppUserAppService appUserAppService)
        {
            _category = category;
            _service = serviceAppService;
            _bid = bidAppService;
            _comment = commentAppService;
            _request  = requestAppService;
            _status = statusAppService;
            _person = personAppService;
            _appuser = appUserAppService;
        }

        
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var adminId = await _appuser.LoggedInUserId();
            var admin = await _person.GetAdmin(adminId, cancellationToken);
            return View(admin);
        }

        #region Lists

        [HttpGet]
        public async Task<IActionResult> CategoryList(CancellationToken cancellationToken)
        {
            var list = await _category.GetAll(cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> RequestList(CancellationToken cancellationToken)
        {
            var list = await _request.GetAll(cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> CommentList(CancellationToken cancellationToken)
        {
            var list = await _comment.GetAll(cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList(CancellationToken cancellationToken)
        {
            var list = await _service.GetAll(cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> BidList(CancellationToken cancellationToken)
        {
            var list = await _bid.GetAll(cancellationToken);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> RequestBids(int requestId, CancellationToken cancellationToken)
        {
            var bids = await _bid.GetAllByRequestId(requestId, cancellationToken);
            if(bids != null)
            {
                    return View(bids);
            }
            return RedirectToAction("Index", "Admin");
        }
        #endregion

        #region Delete Actions

        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id,CancellationToken cancellationToken)
        {
            await _comment.Delete(id, cancellationToken);
            return RedirectToAction("CommentList","Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id,CancellationToken cancellationToken)
        {
            await _comment.Delete(id, cancellationToken);
            return RedirectToAction("CategoryList", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteService(int id,CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
            return RedirectToAction("ServiceList", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRequest(int id,CancellationToken cancellationToken)
        {
            await _request.Delete(id, cancellationToken);
            return RedirectToAction("RequestList", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBid(int id,CancellationToken cancellationToken)
        {
            await _bid.Delete(id, cancellationToken);
            return RedirectToAction("BidList", "Admin");
        }

        #endregion

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO category,CancellationToken cancellationToken)
        {
            var dto = new CategoryDTO()
            {
                Title = category.Title,
                IsActive = category.IsActive,
            };
            await _category.Create(dto, cancellationToken);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> CreateService(CancellationToken cancellationToken)
        {
            var categories = await _category.GetAll(cancellationToken);
            ViewBag.Categories = categories
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceDTO service,CancellationToken cancellationToken)
        {
            var dto = new ServiceDTO
            {
                Title = service.Title,
                IsActive = service.IsActive,
                CategoryId = service.CategoryId,
                Description = service.Description,
            };
            await _service.Create(dto, cancellationToken);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> EditRequest(int id,CancellationToken cancellationToken)
        {
            var statuses = await _status.GetAll(cancellationToken);
            ViewBag.Statuses = statuses
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Massage
                });
            var request = await _request.GetByRequestId(id, cancellationToken);
            var dto = new RequestDTO
            {
                Id = request.Id,
                StatusId = request.StatusId,
                Price = request.Price,
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest(RequestDTO requestDTO,CancellationToken cancellationToken)
        {
            var dto = new RequestDTO
            {
                Id = requestDTO.Id,
                Price = requestDTO.Price,
                StatusId = requestDTO.StatusId,
            };
            var statuses = await _status.GetAll(cancellationToken);
            await _request.Update(dto, cancellationToken);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> ApproveBid(int expertid,int requestid,int bidid,CancellationToken cancellationToken)
        {
            await _bid.Approve(expertid,requestid,bidid,cancellationToken);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> SeeRequest(int id,CancellationToken cancellationToken)
        {
            var request = await _request.GetByRequestId(id, cancellationToken);
            return View(request);
        }
    }
}
