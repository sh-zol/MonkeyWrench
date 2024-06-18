using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.AppServices
{
    public interface IServiceAppService
    {
        Task Create(ServiceDTO serviceDTO, CancellationToken cancellationToken);
        Task Update(ServiceDTO serviceDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<ServiceDTO>> GetAll(CancellationToken cancellationToken);
        Task<ServiceDTO>? GetByTitle(string title, CancellationToken cancellationToken);
        Task<ServiceDTO>? GetByServiceId(int serviceId, CancellationToken cancellationToken);
        Task<List<ServiceDTO>>? GetByCategoryId(int categoryId, CancellationToken cancellationToken);
    }
}
