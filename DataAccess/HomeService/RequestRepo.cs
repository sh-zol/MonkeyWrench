using DataBase.Context;
using FrameWork;
using Domain.Core.HomeService.Contracts.Repositories;
using Domain.Core.HomeService.DTOS;
using Domain.Core.User.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HomeService
{
    public class RequestRepo : IRequestRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<RequestRepo> _logger;

        public RequestRepo(AppDBContext context,
            ILogger<RequestRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(RequestDTO requestDTO, CancellationToken cancellationToken)
        {
            var request = new RequestDTO
            {
                Title = requestDTO.Title,
                Description = requestDTO.Description,
                Address = requestDTO.Address,
                CreatedDate = DateTime.Now,
                CustomerId = requestDTO.CustomerId,
                ServiceId = requestDTO.ServiceId,
                DeadLine = requestDTO.DeadLine,
                DeadLineFa = requestDTO.DeadLineFa,
                FileLocation = requestDTO.FileLocation,
                StatusId = 1,
            };
            await _context.Requests.AddAsync(request, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("request has been created");
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"request with the id of {request.Id} has been deleted");
            }
        }

        public async Task<List<RequestDTO>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Requests.AsNoTracking().Select(x => new RequestDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Address = x.Address,
                CreatedDate = x.CreatedDate,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.FullName,
                ExpertName = x.Expert.FullName,
                StatusTitle = x.Status.Massage,
                BidDTOs = x.Bids.Select(b=>new BidDTO
                {
                    Id = b.Id,
                    ExpertName = x.Expert.FullName,
                    CreatedAt = x.CreatedDate,
                    ExpertId = b.ExpertId,
                    IsAccepted = b.IsAccepted,
                    RequestId = b.RequestId,
                    Price = b.Price
                }).ToList(),
                Comments = x.Comments,
                Customer = x.Customer,
                DeadLine = x.DeadLine,
                Expert = x.Expert,
                ExpertId = x.ExpertId,
                Price = x.Price,
                Service = x.Service,
                FileLocation = x.FileLocation,
                ServiceId = x.ServiceId,
                Status = x.Status,
                StatusId = x.StatusId,
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no request was found");
                return new List<RequestDTO>();
            }
        }

        public async Task<List<RequestDTO>?> GetAllByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            var list = await _context.Requests.AsNoTracking().Where(x => x.CustomerId == customerId).Select(x => new RequestDTO
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Address = x.Address,
                Bids = x.Bids,
                Comments = x.Comments,
                Customer = x.Customer,
                DeadLine = x.DeadLine,
                Expert = x.Expert,
                ExpertId = x.ExpertId,
                Price = x.Price,
                Service = x.Service,
                FileLocation = x.FileLocation,
                ServiceId = x.ServiceId,
                Status = x.Status,
                StatusId = x.StatusId,
                StatusTitle = x.Status.Massage,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Title = x.Title,

            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no requests was found");
                return new List<RequestDTO>();
            }
        }

        public async Task<List<RequestDTO>?> GetAllByExpertId(ExpertDTO expert, CancellationToken cancellationToken)
        {
            var list = await _context.Requests.AsNoTracking()
                .Where(x => x.ExpertId == expert.Id)
                .Select(x => new RequestDTO
                {
                    Id = x.Id,
                    ExpertId = x.ExpertId,
                    Address = x.Address,
                    CreatedDate = x.CreatedDate,
                    Customer = x.Customer,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.FullName,
                    DeadLine = x.DeadLine,
                    Description = x.Description,
                    Expert = x.Expert,
                    ExpertName = x.Expert.FullName,
                    Price = x.Price,
                    Service = x.Service,
                    ServiceId = x.ServiceId,
                    Status = x.Status,
                    FileLocation = x.FileLocation,
                    StatusId = x.StatusId,
                    Title = x.Title,
                    StatusTitle = x.Status.Massage
                }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no data was found");
                return new List<RequestDTO>();
            }
        }

        public async Task<List<RequestDTO>?> GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            var list = await _context.Requests.AsNoTracking().Where(x => x.Id == requestId).Select(x => new RequestDTO
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Address = x.Address,
                CustomerName = x.Customer.FullName,
                ExpertName = x.Expert.FullName,
                StatusTitle = x.Status.Massage,
                BidDTOs = x.Bids.Select(b => new BidDTO
                {
                    Id = b.Id,
                    ExpertName = x.Expert.FullName,
                    CreatedAt = x.CreatedDate,
                    ExpertId = b.ExpertId,
                    IsAccepted = b.IsAccepted,
                    RequestId = b.RequestId,
                    Price = b.Price
                }).ToList(),
                Price = x.Price,
                StatusId = x.StatusId,
                ExpertId = x.ExpertId,
                Comments = x.Comments,
                CreatedDate = x.CreatedDate,
                Customer = x.Customer,
                DeadLine = x.DeadLine,
                Description = x.Description,
                Expert = x.Expert,
                FileLocation = x.FileLocation,
                File = x.File,
                Service = x.Service,
                ServiceId = x.ServiceId,
                Status = x.Status,
                Title = x.Title
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no request was found");
                return new List<RequestDTO>();
            }
        }

        public async Task<List<RequestDTO>?> GetAllByServiceId(List<int> serviceIds, CancellationToken cancellationToken)
        {
            if(serviceIds == null)
            {
                _logger.LogError("no service was assigned by expert");
                return null;
            }

            var requests = await _context.Requests.AsNoTracking().Where(x => serviceIds.Contains(x.ServiceId)).
                Select(x => new RequestDTO
                {
                    Id = x.Id,
                    ServiceId = x.ServiceId,
                    Title = x.Title,
                    Description = x.Description,
                    CustomerName = x.Customer.FullName,
                    ExpertName = x.Expert.FullName,
                    StatusTitle = x.Status.Massage,
                }).ToListAsync(cancellationToken);
            return requests;
        }

        public async Task<List<RequestDTO>?> GetAllExpertRequests(ExpertDTO expert, CancellationToken cancellationToken)
        {
            var result = await _context.Requests.AsNoTracking()
                .Where(x => expert.Skills
                .Select(x => x.ServiceId)
                .Contains(x.Service.Id) && x.StatusId == 1 || x.StatusId == 2 || x.StatusId == 3 || x.StatusId == 4)
                .Select(x => new RequestDTO
                {
                    Id = x.Id,
                    StatusId = x.StatusId,
                    Service = x.Service,
                    Address = x.Address,
                    CreatedDate = x.CreatedDate,
                    Customer = x.Customer,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.FullName,
                    StatusTitle = x.Status.Massage,
                    DeadLine = x.DeadLine,
                    Description = x.Description,
                    Expert = x.Expert,
                    ExpertId = x.ExpertId,
                    FileLocation = x.FileLocation,
                    File = x.File,
                    Price = x.Price,
                    ServiceId = x.ServiceId,
                    Status = x.Status,
                    Title = x.Title,
                    BidDTOs = x.Bids.Select(b => new BidDTO
                    {
                        Id = b.Id,
                        ExpertName = x.Expert.FullName,
                        CreatedAt = x.CreatedDate,
                        ExpertId = b.ExpertId,
                        IsAccepted = b.IsAccepted,
                        RequestId = b.RequestId,
                        Price = b.Price
                    }).ToList(),
                    CommentDTOs = x.Comments.Select(x => new CommentDTO
                    {
                        Id = x.Id,
                        Description = x.Description,
                        CustomerId = x.CustomerId,
                        RequestId = x.RequestId,
                        ServiceId = x.ServiceId
                    }).ToList(),
                }).ToListAsync(cancellationToken);
            if(result != null)
            {
                return result;
            }
            else
            {
                _logger.LogError("no request was found");
                return new List<RequestDTO>();
            }
        }

        public async Task<List<RequestDTO>?> GetAllProcceingRequests(ExpertDTO expert, CancellationToken cancellationToken)
        {
            var list = await _context.Requests.AsNoTracking().Where(x => x.ExpertId == expert.Id && expert.Skills
            .Select(x => x.Id)
            .Contains(x.Service.Id) && x.StatusId == 3 || x.StatusId == 4)
            .Select(x => new RequestDTO
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                Address = x.Address,
                Customer = x.Customer,
                StatusId = x.StatusId,
                Service = x.Service,
                CustomerName = x.Customer.FullName,
                Title = x.Title,
                CustomerId = x.CustomerId,
                DeadLine = x.DeadLine,
                Description = x.Description,
                Status = x.Status,
                Expert = x.Expert,
                ExpertId = x.Id,
                Price = x.Price,
                ExpertName = x.Expert.FullName,
                StatusTitle = x.Status.Massage,
                CommentDTOs = x.Comments.Select(x => new CommentDTO
                {
                    Id = x.Id,
                    // Customer = x.Customer,
                    CustomerId = x.CustomerId,
                    Description = x.Description,
                    RequestId = x.RequestId,
                    ServiceId = x.ServiceId
                }).ToList(),
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no request was found");
                return new List<RequestDTO>();
            }
        }

        public async Task<RequestDTO>? GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.AsNoTracking().Where(x => x.Id == requestId).Select(x => new RequestDTO
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                DeadLine = x.DeadLine,
                Description = x.Description,
                Status = x.Status,
                Expert = x.Expert,
                ExpertId = x.ExpertId,
                Address = x.Address,
                CreatedDate = x.CreatedDate,
                Customer = x.Customer,
                CustomerName = x.Customer.FullName,
                File = x.File,
                FileLocation = x.FileLocation,
                Price = x.Price,
                ExpertName = x.Expert.FullName,
                Service = x.Service,
                ServiceId = x.ServiceId,
                StatusId = x.StatusId,
                StatusTitle = x.Status.Massage,
                Title = x.Title,
                BidDTOs = x.Bids.Select(b => new BidDTO
                {
                    Id = b.Id,
                    ExpertName = x.Expert.FullName,
                    CreatedAt = x.CreatedDate,
                    ExpertId = b.ExpertId,
                    IsAccepted = b.IsAccepted,
                    RequestId = b.RequestId,
                    Price = b.Price
                }).ToList(),
                CommentDTOs = x.Comments.Select(x => new CommentDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    CustomerId = x.CustomerId,
                    RequestId = x.RequestId,
                    ServiceId = x.ServiceId
                }).ToList(),
            }).SingleOrDefaultAsync(cancellationToken);
            if(request != null)
            {
                return request;
            }
            else
            {
                _logger.LogError($"request with the id of {request.Id} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(RequestDTO requestDTO, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestDTO.Id, cancellationToken);
            if(request != null)
            {
                request.StatusId = requestDTO.StatusId;
                request.Price = requestDTO.Price;
                request.ExpertId = requestDTO.ExpertId;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"request with the id of {request.Id} has been updated");
            }
            
        }
    }
}
