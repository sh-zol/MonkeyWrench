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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _repo;

        public CommentService(ICommentRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(CommentDTO commentDTO, CancellationToken cancellationToken)
        {
            await _repo.Create(commentDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repo.Delete(id, cancellationToken);
        }

        public async Task<List<CommentDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<List<CommentDTO>>? GetAllByRequestId(int orderId, CancellationToken cancellationToken)
        {
            return await _repo.GetAllByRequestId(orderId, cancellationToken);
        }

        public async Task<CommentDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetById(id, cancellationToken);
        }

        public async Task<CommentDTO>? GetByRequestId(int orderId, CancellationToken cancellationToken)
        {
            return await _repo.GetByRequestId(orderId, cancellationToken);
        }

        public async Task Update(CommentDTO commentDTO, CancellationToken cancellationToken)
        {
            await _repo.Update(commentDTO, cancellationToken);
        }
    }
}
