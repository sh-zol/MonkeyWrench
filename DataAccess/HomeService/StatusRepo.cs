using DataBase.Context;
using Domain.Core.HomeService.Contracts.Repositories;
using Domain.Core.HomeService.DTOS;
using Domain.Core.HomeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HomeService
{
    public class StatusRepo : IStatusRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<StatusRepo> _logger;

        public StatusRepo(ILogger<StatusRepo> logger,
            AppDBContext appDBContext)
        {
            _logger = logger;
            _context = appDBContext;
        }

        public async Task Create(StatusDTO statusDTO, CancellationToken cancellationToken)
        {
            var status = new Status
            {
                Massage = statusDTO.Massage,
            };
            await _context.AddAsync(status,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("new status has been created");
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(x=> x.Id == id,cancellationToken);
            if (status != null)
            {
                _context.Statuses.Remove(status);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"status with the id of {status.Id} has been deleted");
            }
        }

        public async Task<List<StatusDTO>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Statuses.Select(x => new StatusDTO
            {
                Id = x.Id,
                Massage = x.Massage,
               // Request = x.Request,
               // RequestId = x.RequestId,
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no status was found");
                return new List<StatusDTO>();
            }
        }

        public async Task<StatusDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var status = await _context.Statuses.Where(x => x.Id == id)
                .Select(x => new StatusDTO
                {
                    Id = id,
                    Massage = x.Massage,
                }).SingleOrDefaultAsync(cancellationToken);
            if (status != null)
            {
                return status;
            }
            else
            {
                _logger.LogError($"status with the id of {id} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(StatusDTO statusDTO, CancellationToken cancellationToken)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(x=>x.Id == statusDTO.Id,cancellationToken);
            if(status != null)
            {
                status.Massage = statusDTO.Massage;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"status with the id of {status.Id} has been updated");
            }
        }
    }
}
