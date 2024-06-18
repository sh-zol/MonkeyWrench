using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.HomeService.Contracts.Services;
using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.HomeService
{
    public class BidAppService : IBidAppService
    {
        private readonly IBidService _service;
        private readonly IRequestAppService _requestAppService;

        public BidAppService(IBidService service, IRequestAppService requestAppService)
        {
            _service = service;
            _requestAppService = requestAppService;
        }

        public async Task Approve(int experId, int requestId, int bidId, CancellationToken cancellationToken)
        {
            await _service.Approve(experId, requestId, bidId, cancellationToken);
        }

        public async Task Create(BidDTO bid, CancellationToken cancellationToken)
        {
            await _service.Create(bid, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        public async Task<List<BidDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task<List<BidDTO>> GetAllByExpertId(int expertId, CancellationToken cancellationToken)
        {
            return await _service.GetAllByExpertId(expertId,cancellationToken);
        }

        public async Task<List<BidDTO>> GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _service.GetAllByRequestId(requestId,cancellationToken);
        }

        public async Task<BidDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        public async Task Update(BidDTO bid, CancellationToken cancellationToken)
        {
            await _service.Update(bid, cancellationToken);
        }
    }
}
