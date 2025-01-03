﻿using Domain.Core.HomeService.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Contracts.AppServices
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDTO>> GetAll(CancellationToken cancellationToken);
        Task<CategoryDTO>? GetByTitle(string title, CancellationToken cancellationToken);
        Task<CategoryDTO>? GetById(int id, CancellationToken cancellationToken);
        Task Create(CategoryDTO categoryDTO, CancellationToken cancellationToken);
        Task Update(CategoryDTO categoryDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
