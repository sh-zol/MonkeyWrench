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
    public class ServiceRepo : IServiceRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<ServiceRepo> _logger;

        public ServiceRepo(AppDBContext context,
            ILogger<ServiceRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(ServiceDTO serviceDTO, CancellationToken cancellationToken)
        {
            var service = new Service
            {
                Title = serviceDTO.Title,
                Description = serviceDTO.Description,
                Category = serviceDTO.Category,
                CategoryId = serviceDTO.CategoryId,
                IsActive = serviceDTO.IsActive,
                

            };
            await _context.Services.AddAsync(service, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("service has been created");
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if(service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"service with the id of {service.Id} has been deleted");
            }
        }

        public async Task<List<ServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Services.AsNoTracking().Select(x => new ServiceDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.Category,
                CategoryId = x.CategoryId,
                IsActive = x.IsActive,
                Comments = x.Comments,
                Requests = x.Requests,
                Skills = x.Skills,
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no service was found");
                return new List<ServiceDTO>();
            }
        }

        public async Task<List<ServiceDTO>>? GetByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var service = await _context.Services.AsNoTracking().Where(x => x.CategoryId == categoryId)
                .Select(x => new ServiceDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Category = x.Category,
                    CategoryId = x.CategoryId,
                    IsActive = x.IsActive,
                    Comments = x.Comments,
                    Requests = x.Requests,
                    Skills = x.Skills,

                }).ToListAsync(cancellationToken);
            if(service != null)
            {
                return service;
            }
            else
            {
                _logger.LogError($"services with the category id of {categoryId} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task<ServiceDTO>? GetByServiceId(int serviceId, CancellationToken cancellationToken)
        {
            var service = await _context.Services.AsNoTracking().Where(x => x.Id == serviceId)
                .Select(x => new ServiceDTO
                {
                    Id = x.Id,
                    Category = x.Category,
                    CategoryId = x.CategoryId,
                    Comments = x.Comments,
                    Description = x.Description,
                    Requests = x.Requests,
                    Skills = x.Skills,
                    IsActive = x.IsActive,
                    Title = x.Title
                }).SingleOrDefaultAsync(cancellationToken);
            if (service != null) { return service; }
            else
            {
                _logger.LogError($"service with the id of {service.Id} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task<ServiceDTO>? GetByTitle(string title, CancellationToken cancellationToken)
        {
            var service = await _context.Services.AsNoTracking().Where(x => x.Title == title)
                .Select(x => new ServiceDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Category,
                    CategoryId = x.CategoryId,
                    Comments = x.Comments,
                    Description = x.Description,
                    Requests = x.Requests,
                    Skills = x.Skills,
                    IsActive = x.IsActive,

                }).SingleOrDefaultAsync(cancellationToken);
            if (service != null) { return service; }
            else
            {
                _logger.LogError($"service with the id of {service.Id} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(ServiceDTO serviceDTO, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x=>x.Id == serviceDTO.Id,cancellationToken);
            if(service != null)
            {
                service.CategoryId = serviceDTO.CategoryId;
                service.Title = serviceDTO.Title;
                service.Description = serviceDTO.Description;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"service with the id of {service.Id} has been updated");
            }
        }
    }
}
