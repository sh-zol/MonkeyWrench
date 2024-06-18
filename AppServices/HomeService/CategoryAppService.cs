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
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _service;

        public CategoryAppService(ICategoryService service)
        {
            _service = service;
        }

        public async Task Create(CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            await _service.Create(categoryDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        public async Task<List<CategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task<CategoryDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        public async Task<CategoryDTO>? GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _service.GetByTitle(title, cancellationToken);
        }

        public async Task Update(CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            await _service.Update(categoryDTO, cancellationToken);
        }
    }
}
