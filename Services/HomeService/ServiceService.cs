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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepo _repo;

        public ServiceService(IServiceRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(ServiceDTO serviceDTO, CancellationToken cancellationToken)
        {
            await _repo.Create(serviceDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repo.Delete(id, cancellationToken);
        }

        public async Task<List<ServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<List<ServiceDTO>>? GetByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            return await _repo.GetByCategoryId(categoryId, cancellationToken);
        }

        public async Task<ServiceDTO>? GetByServiceId(int serviceId, CancellationToken cancellationToken)
        {
            return await _repo.GetByServiceId(serviceId, cancellationToken);
        }

        public async Task<ServiceDTO>? GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _repo.GetByTitle(title, cancellationToken);
        }

        public async Task Update(ServiceDTO serviceDTO, CancellationToken cancellationToken)
        {
            await _repo.Update(serviceDTO, cancellationToken);
        }
    }
}
