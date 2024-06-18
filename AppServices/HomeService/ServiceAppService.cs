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
    public class ServiceAppService : IServiceAppService
    {
        private readonly IServiceService _service;

        public ServiceAppService(IServiceService service)
        {
            _service = service;
        }

        public async Task Create(ServiceDTO serviceDTO, CancellationToken cancellationToken)
        {
            await _service.Create(serviceDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        public async Task<List<ServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task<List<ServiceDTO>>? GetByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            return await _service.GetByCategoryId(categoryId, cancellationToken);
        }

        public async Task<ServiceDTO>? GetByServiceId(int serviceId, CancellationToken cancellationToken)
        {
            return await _service.GetByServiceId(serviceId, cancellationToken);
        }

        public async Task<ServiceDTO>? GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _service.GetByTitle(title, cancellationToken);
        }

        public async Task Update(ServiceDTO serviceDTO, CancellationToken cancellationToken)
        {
            await _service.Update(serviceDTO, cancellationToken);
        }
    }
}
