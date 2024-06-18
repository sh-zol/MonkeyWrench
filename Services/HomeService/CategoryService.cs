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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repo;

        public CategoryService(ICategoryRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            await _repo.Create(categoryDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repo.Delete(id, cancellationToken);
        }

        public async Task<List<CategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<CategoryDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetById(id, cancellationToken);
        }

        public async Task<CategoryDTO>? GetByTitle(string title, CancellationToken cancellationToken)
        {
            return await _repo.GetByTitle(title, cancellationToken);
        }

        public async Task Update(CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
             await _repo.Update(categoryDTO, cancellationToken);
        }
    }
}
