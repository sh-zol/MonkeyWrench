using Domain.Core.HomeService.Contracts.Repositories;
using Domain.Core.HomeService.Contracts.Services;
using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.HomeService
{
    public class BidService : IBidService
    {
        private readonly IBidRepo _repo;
        private readonly IRequestRepo _request;

        public BidService(IBidRepo repo, IRequestRepo request)
        {
            _repo = repo;
            _request = request;
        }

        public async Task Approve(int experId, int requestId, int bidId, CancellationToken cancellationToken)
        {
            var bids = await _repo.GetAllByRequestId(requestId, cancellationToken);
            foreach(var bid in bids)
            {
                bid.IsAccepted = false;
                await _repo.Update(bid, cancellationToken);
            }
            var recbid = await _repo.GetById(bidId, cancellationToken);
            recbid.IsAccepted = true;
            var request = await _request.GetByRequestId(requestId, cancellationToken);
            request.StatusId = 2;
            request.ExpertId = experId;
            request.Price = recbid.Price;
            await _repo.Update(recbid, cancellationToken);
            await _request.Update(request, cancellationToken);
        }

        public async Task Create(BidDTO bid, CancellationToken cancellationToken)
        {
            await _repo.Create(bid,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repo.Delete(id, cancellationToken);
        }

        public async Task<List<BidDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<List<BidDTO>> GetAllByExpertId(int expertId, CancellationToken cancellationToken)
        {
            return await _repo.GetAllByExpertId(expertId, cancellationToken);
        }

        public async Task<List<BidDTO>> GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _repo.GetAllByRequestId(requestId, cancellationToken);
        }

        public async Task<BidDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetById(id, cancellationToken);
        }

        public async Task Update(BidDTO bid, CancellationToken cancellationToken)
        {
            await _repo.Update(bid, cancellationToken);
        }
    }
}
