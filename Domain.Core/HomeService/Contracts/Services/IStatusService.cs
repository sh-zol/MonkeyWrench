using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.Services
{
    public interface IStatusService
    {
        Task Create(StatusDTO statusDTO, CancellationToken cancellationToken);
        Task Update(StatusDTO statusDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<StatusDTO> GetById(int id, CancellationToken cancellationToken);
        Task<List<StatusDTO>> GetAll(CancellationToken cancellationToken);
    }
}
