using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.Services
{
    public interface ICommentService
    {
        Task Create(CommentDTO commentDTO, CancellationToken cancellationToken);
        Task Update(CommentDTO commentDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<CommentDTO>> GetAll(CancellationToken cancellationToken);
        Task<CommentDTO>? GetByRequestId(int orderId, CancellationToken cancellationToken);
        Task<List<CommentDTO>>? GetAllByRequestId(int orderId, CancellationToken cancellationToken);
        Task<CommentDTO>? GetById(int id, CancellationToken cancellationToken);
    }
}
