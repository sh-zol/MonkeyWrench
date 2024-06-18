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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<CategoryRepo> _logger;

        public CategoryRepo(AppDBContext context,
            ILogger<CategoryRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Title = categoryDTO.Title,
                IsActive = categoryDTO.IsActive,

            };
            await _context.Categories.AddAsync(category,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("category has been added");
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x=>x.Id == id,cancellationToken);
            if(category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogError($"category with the id of {category.Id} has been deleted");
            }
        }

        public async Task<List<CategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Categories.Select(x => new CategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                IsActive = x.IsActive,
                Services = x.Services,
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                return new List<CategoryDTO>();
            }
        }

        public async Task<CategoryDTO>? GetById(int id, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(x=>x.Id == id).Select(x=> new CategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                IsActive = x.IsActive,
                Services = x.Services,
            }).SingleOrDefaultAsync(cancellationToken);
            if(category != null)
            {
                return category;
            }
            else
            {
                _logger.LogError("no category was found");
                throw new NullReferenceException();
            }
        }

        public async Task<CategoryDTO>? GetByTitle(string title, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(x => x.Title == title).Select(x => new CategoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                IsActive = x.IsActive,
                Services = x.Services,
            }).SingleOrDefaultAsync(cancellationToken);
            if (category != null) { return category; }
            else
            {
                _logger.LogError("no category was found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x=>x.Id == categoryDTO.Id,cancellationToken);
            if( category != null )
            {
                category.Title = categoryDTO.Title;
                category.IsActive = categoryDTO.IsActive;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"category with the id of {category.Id} has been updated");
            }
        }
    }
}
