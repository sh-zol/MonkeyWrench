using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.AppServices
{
    public interface IBidAppService
    {
        Task Approve(int experId, int requestId, int bidId, CancellationToken cancellationToken);
        Task Create(BidDTO bid, CancellationToken cancellationToken);
        Task Update(BidDTO bid, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<BidDTO>> GetAll(CancellationToken cancellationToken);
        Task<List<BidDTO>> GetAllByExpertId(int expertId, CancellationToken cancellationToken);
        Task<List<BidDTO>> GetAllByRequestId(int requestId, CancellationToken cancellationToken);
        Task<BidDTO>? GetById(int id, CancellationToken cancellationToken);
    }
}
