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
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _service;

        public CommentAppService(ICommentService service)
        {
            _service = service;
        }

        public async Task Create(CommentDTO commentDTO, CancellationToken cancellationToken)
        {
            await _service.Create(commentDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        public async Task<List<CommentDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task<List<CommentDTO>>? GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _service.GetAllByRequestId(requestId, cancellationToken);
        }

        public async Task<CommentDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        public async Task<CommentDTO>? GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _service.GetByRequestId(requestId, cancellationToken);
        }

        public async Task Update(CommentDTO commentDTO, CancellationToken cancellationToken)
        {
            await _service.Update(commentDTO, cancellationToken);
        }
    }
}
