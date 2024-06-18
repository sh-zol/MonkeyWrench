using Domain.Core.HomeService.Contracts.Repositories;
using Domain.Core.HomeService.Contracts.Services;
using Domain.Core.HomeService.DTOS;
using Domain.Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.HomeService
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepo _repo;

        public RequestService(IRequestRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(RequestDTO requestDTO, CancellationToken cancellationToken)
        {
            await _repo.Create(requestDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repo.Delete(id, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            return await _repo.GetAllByCustomerId(customerId, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllByExpertId(ExpertDTO expert, CancellationToken cancellationToken)
        {
            return await _repo.GetAllByExpertId(expert, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _repo.GetAllByRequestId(requestId, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllExpertRequests(ExpertDTO expert, CancellationToken cancellationToken)
        {
            return await _repo.GetAllExpertRequests(expert, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllProcceingRequests(ExpertDTO expert, CancellationToken cancellationToken)
        {
            return await _repo.GetAllExpertRequests(expert, cancellationToken);
        }

        public async Task<RequestDTO>? GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _repo.GetByRequestId(requestId, cancellationToken);
        }

        public async Task Update(RequestDTO requestDTO, CancellationToken cancellationToken)
        {
            await _repo.Update(requestDTO, cancellationToken);
        }
    }
}
