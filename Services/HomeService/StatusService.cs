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
    public class StatusService : IStatusService
    {
        private readonly IStatusRepo _repo;

        public StatusService(IStatusRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(StatusDTO statusDTO, CancellationToken cancellationToken)
        {
            await _repo.Create(statusDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repo.Delete(id, cancellationToken); 
        }

        public async Task<List<StatusDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<StatusDTO> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetById(id, cancellationToken);
        }

        public async Task Update(StatusDTO statusDTO, CancellationToken cancellationToken)
        {
            await _repo.Update(statusDTO, cancellationToken);
        } 
    }
}
