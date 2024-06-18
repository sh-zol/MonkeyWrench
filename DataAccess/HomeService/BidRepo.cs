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
    public class BidRepo : IBidRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<BidRepo> _logger;

        public BidRepo(AppDBContext context,
            ILogger<BidRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(BidDTO bid, CancellationToken cancellationToken)
        {
            var bidToAdd = new Bid()
            {
                Description = bid.Description,
                RequestId = bid.RequestId,
                ExpertId = bid.ExpertId,
                Price = bid.Price,
                DeadLine = bid.DeadLine,
                CreatedAt = DateTime.Now,
                IsAccepted = false,
            };
            await _context.Bids.AddAsync(bidToAdd,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("bid has been created");
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var bid = await _context.Bids.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
            if (bid != null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"bid with the id of {bid.Id} has been deleted");
            }
            else
            {
                _logger.LogError("bid not found");
            }
        }

        public async Task<List<BidDTO>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Bids.Select(x => new BidDTO
            {
                Id = x.Id,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                IsAccepted = x.IsAccepted,
                DeadLine = x.DeadLine,
                Expert = x.Expert,
                ExpertName = x.Expert.FullName,
                ExpertId = x.ExpertId,
                Price = x.Price,
                Request = x.Request,
                RequestId = x.RequestId
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no bids was found");
                return new List<BidDTO>();
            }
        }

        public async Task<List<BidDTO>> GetAllByExpertId(int expertId, CancellationToken cancellationToken)
        {
            var list = await _context.Bids.Where(x => x.ExpertId == expertId).Select(x => new BidDTO
            {
                Id = x.Id,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                IsAccepted = x.IsAccepted,
                DeadLine = x.DeadLine,
                Expert = x.Expert,
                ExpertName = x.Expert.FullName,
                ExpertId = x.ExpertId,
                Price = x.Price,
                Request = x.Request,
                RequestId = x.RequestId
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no bids was found");
                return new List<BidDTO>();
            }
        }

        public async Task<List<BidDTO>> GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            var list = await _context.Bids.Where(x => x.RequestId == requestId).Select(x => new BidDTO
            {
                Id = x.Id,
                RequestId = x.RequestId,
                CreatedAt = x.CreatedAt,
                DeadLine = x.DeadLine,
                Expert = x.Expert,
                ExpertName = x.Expert.FullName,
                ExpertId = x.ExpertId,
                Price = x.Price,
                Request = x.Request,
                Description = x.Description,
                IsAccepted = x.IsAccepted
            }).ToListAsync(cancellationToken);
            if( list != null) { return list; }
            else
            {
                _logger.LogError("no bids was found");
                return new List<BidDTO>();
            }
        }

        public async Task<BidDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            var bid = await _context.Bids.Where(x => x.Id == id).Select(x => new BidDTO
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                DeadLine = x.DeadLine,
                Expert = x.Expert,
                ExpertId = x.ExpertId,
                ExpertName = x.Expert.FullName,
                Price = x.Price,
                Request = x.Request,
                Description = x.Description,
                IsAccepted = x.IsAccepted,
                RequestId = x.RequestId
            }).SingleOrDefaultAsync(cancellationToken);
            if (bid != null) 
            {
                _logger.LogInformation("bid was found");
                return bid; 
            }
            else
            {
                _logger.LogError($"bid with the id of {bid.Id} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(BidDTO bid, CancellationToken cancellationToken)
        {
            var bidToUpdate = await _context.Bids.FirstOrDefaultAsync(x=>x.Id == bid.Id,cancellationToken);
            if(bidToUpdate != null)
            {
                bidToUpdate.RequestId = bid.RequestId;
                bidToUpdate.ExpertId = bid.ExpertId;
                bidToUpdate.Price = bid.Price;
                bidToUpdate.IsAccepted = bid.IsAccepted;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"bid with the id of {bid.Id} has been updated");
            }
        }
    }
}
