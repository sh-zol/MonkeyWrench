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
    public class StatusAppService : IStatusAppService
    {
        private readonly IStatusService _service;

        public StatusAppService(IStatusService service)
        {
            _service = service;
        }

        public async Task Create(StatusDTO statusDTO, CancellationToken cancellationToken)
        {
            await _service.Create(statusDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        public async Task<List<StatusDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task<StatusDTO> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        public async Task Update(StatusDTO statusDTO, CancellationToken cancellationToken)
        {
            await _service.Update(statusDTO, cancellationToken);
        }
    }
}
