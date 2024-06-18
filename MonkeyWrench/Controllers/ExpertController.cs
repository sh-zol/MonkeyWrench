using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.HomeService.DTOS;
using Domain.Core.User.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MonkeyWrench.Controllers
{
    [Authorize(Roles = "Expert")]
    public class ExpertController : Controller
    {
        private readonly IBidAppService _bid;
        private readonly IRequestAppService _request;
        private readonly IAppUserAppService _appuser;
        private readonly IPersonAppService _person;
        private readonly ICommentAppService _comment;
        public ExpertController(IBidAppService bidAppService,
            IRequestAppService requestAppService,
            IAppUserAppService appUserAppService,
            IPersonAppService personAppService,
            ICommentAppService comment)
        {
            _appuser = appUserAppService;
            _bid = bidAppService;
            _request = requestAppService;
            _person = personAppService;
            _comment = comment;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var expertId = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(expertId, cancellationToken);
            return View(expert);
        }

        [HttpGet]
        public async Task<IActionResult> ExpertRequests(CancellationToken cancellationToken)
        {
            var expertId = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(expertId, cancellationToken);
            ViewBag.ExpertId = expert.Id;
            var requests = await _request.GetAllExpertRequests(cancellationToken);
            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> ExpertFinished(CancellationToken cancellationToken)
        {
            var expertId = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(expertId, cancellationToken);
            ViewBag.ExpertId = expert.Id;
            var requests = await _request.GetAllByExpertId(cancellationToken);
            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> ExpertProccesing(CancellationToken cancellationToken)
        {
            var expertId = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(expertId, cancellationToken);
            ViewBag.ExpertId = expert.Id;
            var requests = await _request.GetAllProcceingRequests(cancellationToken);
            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> RequestDetails(int requestId, CancellationToken cancellationToken)
        {
            var request = await _request.GetByRequestId(requestId, cancellationToken);
            var expertId = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(expertId, cancellationToken);
            return View(request);
        }

        [HttpGet]
        public IActionResult CreateBid(int requestId)
        {
            ViewBag.RequestId = Convert.ToInt32(requestId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBid(BidDTO bidDTO, int requestId, CancellationToken cancellationToken)
        {
            var expertId = await _appuser.LoggedInUserId();
            var expert = await _person.GetExpert(expertId, cancellationToken);
                var dto = new BidDTO
                {
                    DeadLine = bidDTO.DeadLine,
                    Description = bidDTO.Description,
                    Price = bidDTO.Price,
                    ExpertId = expert.Id,
                    RequestId = requestId,
                    CreatedAt = DateTime.Now,
                };
                await _bid.Create(dto, cancellationToken);
                return RedirectToAction("Index", "Expert");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBid(int bidId,CancellationToken cancellationToken)
        {
            await _bid.Delete(bidId, cancellationToken);
            return RedirectToAction("Index", "Expert");
        }

        [HttpGet]
        public async Task<IActionResult> ShowComment(int requestId,CancellationToken cancellationToken)
        {
            var comments = await _comment.GetAllByRequestId(requestId, cancellationToken);
            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> NextStatus(int requestId,CancellationToken cancellationToken)
        {
            var request = await _request.GetByRequestId(requestId, cancellationToken);
            request.StatusId++;
            await _request.Update(request,cancellationToken);
            return RedirectToAction("Index", "Expert");
        } 
    }
}
