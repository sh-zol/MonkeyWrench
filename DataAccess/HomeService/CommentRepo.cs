using DataBase.Context;
using Domain.Core.HomeService.Contracts.Repositories;
using Domain.Core.HomeService.DTOS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HomeService
{
    public class CommentRepo : ICommentRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<CommentRepo> _logger;

        public CommentRepo(AppDBContext context,
            ILogger<CommentRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(CommentDTO commentDTO, CancellationToken cancellationToken)
        {
            var comment = new CommentDTO
            {
                Service = commentDTO.Service,
                ServiceId = commentDTO.ServiceId,
                Customer = commentDTO.Customer,
                CustomerId = commentDTO.CustomerId,
                Request = commentDTO.Request,
                RequestId = commentDTO.RequestId,
                Description = commentDTO.Description
            };
            await _context.Comments.AddAsync(comment,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("comment has been created");
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x=>x.Id == id,cancellationToken);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"comment with the id of {comment.Id} has been deleted");
            }
        }

        public async Task<List<CommentDTO>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Comments.AsNoTracking().Select(x => new CommentDTO
            {
                Id = x.Id,
                Customer = x.Customer,
                CustomerId = x.CustomerId,
                Request = x.Request,
                RequestId = x.RequestId,
                Description = x.Description,
                Service = x.Service,
                ServiceId = x.ServiceId,
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no comment was found");
                return new List<CommentDTO>();
            }
        }

        public async Task<List<CommentDTO>>? GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            var list = await _context.Comments.AsNoTracking().Where(x => x.RequestId == requestId).Select(x => new CommentDTO
            {
                Id = x.Id,
                Customer = x.Customer,
                CustomerId = x.CustomerId,
                Request = x.Request,
                RequestId = x.RequestId,
                Description = x.Description,
                Service = x.Service,
                ServiceId = x.ServiceId,

            }).ToListAsync(cancellationToken);
            if(list != null) { return list; }
            else
            {
                _logger.LogError("no comment was found");
                return new List<CommentDTO>();
            }
        }

        public async Task<CommentDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.AsNoTracking().Where(x => x.Id == id).Select(x => new CommentDTO
            {
                Id = x.Id,
                Customer = x.Customer,
                CustomerId = x.CustomerId,
                Request = x.Request,
                RequestId = x.RequestId,
                Description = x.Description,
                Service = x.Service,
                ServiceId = x.ServiceId,

            }).SingleOrDefaultAsync(cancellationToken);
            if(comment != null) { return comment; }
            else
            {
                _logger.LogError($"comment with the id of {comment.Id} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task<CommentDTO>? GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.AsNoTracking().Where(x => x.RequestId == requestId).Select(x => new CommentDTO
            {
                Id = x.Id,
                Customer = x.Customer,
                CustomerId = x.CustomerId,
                Request = x.Request,
                RequestId = x.RequestId,
                Description = x.Description,
                Service = x.Service,
                ServiceId = x.ServiceId,

            }).SingleOrDefaultAsync(cancellationToken);
            if (comment != null) { return comment; }
            else
            {
                _logger.LogError($"comment with the request id of {comment.Id} was not found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(CommentDTO commentDTO, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x=>x.Id ==  commentDTO.Id,cancellationToken);
            if (comment != null)
            {
                comment.ServiceId = commentDTO.ServiceId;
                comment.CustomerId = commentDTO.CustomerId;
                comment.RequestId = commentDTO.RequestId;
                comment.Description = commentDTO.Description;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"comment with the id of {comment.Id} has been updated");
            }
        }

    }
}
