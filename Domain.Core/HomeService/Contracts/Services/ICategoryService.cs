using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAll(CancellationToken cancellationToken);
        Task<CategoryDTO>? GetByTitle(string title, CancellationToken cancellationToken);
        Task<CategoryDTO>? GetById(int id, CancellationToken cancellationToken);
        Task Create(CategoryDTO categoryDTO, CancellationToken cancellationToken);
        Task Update(CategoryDTO categoryDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
