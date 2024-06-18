using Domain.Core.HomeService.DTOS;
using Domain.Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.Repositories
{
    public interface IRequestRepo
    {
        Task Create(RequestDTO requestDTO,CancellationToken cancellationToken);
        Task Update(RequestDTO requestDTO,CancellationToken cancellationToken);
        Task Delete(int id,CancellationToken cancellationToken);
        Task<List<RequestDTO>> GetAll(CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllByCustomerId(int customerId, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllByExpertId(ExpertDTO expert, CancellationToken cancellationToken);
        Task<RequestDTO>? GetByRequestId(int requestId, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllByRequestId(int requestId, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllExpertRequests(ExpertDTO expert, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllProcceingRequests(ExpertDTO expert, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllByServiceId(List<int> serviceIds, CancellationToken cancellationToken);
    }
}
