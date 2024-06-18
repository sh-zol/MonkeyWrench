using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.HomeService.DTOS;
using Domain.Core.User.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonkeyWrench.Models.VMs;

namespace MonkeyWrench.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private readonly IRequestAppService _request;
        private readonly ICommentAppService _comment;
        private readonly IBidAppService _bid;
        private readonly IAppUserAppService _appuser;
        private readonly IPersonAppService _person;

        public CustomerController(IRequestAppService request,
            ICommentAppService commentAppService,
            IBidAppService bidAppService,
            IAppUserAppService appUserAppService,
            IPersonAppService personAppService)
        {
            _request = request;
            _comment = commentAppService;
            _bid = bidAppService;
            _appuser = appUserAppService;
            _person = personAppService;
        }

        
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var customerId = await _appuser.LoggedInUserId();
            var customer = await _person.GetCustomer(customerId, cancellationToken);
            return View(customer);
        }

        [HttpGet]
        public IActionResult CreateRequest(int serviceId)
        {
            ViewBag.ServiceId = Convert.ToInt32(serviceId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(RequestVM requestVM,IFormFile file,int serviceId,CancellationToken cancellationToken)
        {
            var customerId = await _appuser.LoggedInUserId();
            var customer = await _person.GetCustomer(customerId, cancellationToken);
                var request = new RequestDTO
                {
                    DeadLine = requestVM.DeadLine,
                    Description = requestVM.Description,
                    Title = requestVM.Title,
                    Address = requestVM.Address,
                    ServiceId = serviceId,
                    FileLocation = requestVM.FileLocation,
                    CustomerId = customer.Id,
                    StatusId = 1
                };
                await _request.Create(request, file, cancellationToken);
                return RedirectToAction("Index", "Customer");
            
           // return View(requestVM);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerRequests(CancellationToken cancellationToken)
        {
            var customerId = await _appuser.LoggedInUserId();
            var customer = await _person.GetCustomer(customerId, cancellationToken);
            ViewBag.CustomerId = customer.Id;
            var requests = await _request.GetAllByCustomerId(customer.Id, cancellationToken);
            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> RequestBids(int requestId,CancellationToken cancellationToken)
        {
            var requestbids = await _bid.GetAllByRequestId(requestId, cancellationToken);
            if(requestbids != null)
            {
                return View(requestbids);
            }
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> ApproveBid(int expertId,int requestId,int bidId,CancellationToken cancellationToken)
        {
            await _bid.Approve(expertId, requestId, bidId, cancellationToken);
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public IActionResult CreateComment(int requestId,int serviceId)
        {
            ViewBag.ServiceId = serviceId;
            ViewBag.RequestId = requestId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentDTO commentDTO,int requestId,int serviceId,CancellationToken cancellationToken)
        {
            var customerId = await _appuser.LoggedInUserId();
            var customerToFind = await _person.GetCustomer(customerId, cancellationToken);
            var comment = new CommentDTO
            {
                CustomerId = customerToFind.Id,
                ServiceId = serviceId,
                Description = commentDTO.Description,
                RequestId = requestId,
            };
            await _comment.Create(comment, cancellationToken);
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> SeeComment(int requestId,CancellationToken cancellationToken)
        {
            var comments = await _comment.GetAllByRequestId(requestId, cancellationToken);
            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerRequestDetails(int requestId,CancellationToken cancellationToken)
        {
            var request = await _request.GetByRequestId(requestId, cancellationToken);
            var customerId = await _appuser.LoggedInUserId();
            var customerToFind = await _person.GetCustomer(customerId, cancellationToken);
            return View(request);
        }
    }
}
