using Domain.Core.HomeService.DTOS;
using Domain.Core.User.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.AppServices
{
    public interface IRequestAppService
    {
        Task Create(RequestDTO requestDTO,IFormFile file,CancellationToken cancellationToken);
        Task Update(RequestDTO requestDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<RequestDTO>> GetAll(CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllByCustomerId(int customerId, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllByExpertId(CancellationToken cancellationToken);
        Task<RequestDTO>? GetByRequestId(int requestId, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllByRequestId(int requestId, CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllExpertRequests(CancellationToken cancellationToken);
        Task<List<RequestDTO>?> GetAllProcceingRequests(CancellationToken cancellationToken);
    }
}
