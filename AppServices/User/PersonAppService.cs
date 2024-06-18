using Domain.Core.User.Contracts.AppServices;
using Domain.Core.User.Contracts.Services;
using Domain.Core.User.DTOs;
using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.User
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IPersonService _service;

        public PersonAppService(IPersonService service)
        {
            _service = service;
        }

        public async Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken)
        {
            return await _service.GetAdmin(id, cancellationToken);
        }

        public async Task<CustomerDTO>? GetCustomer(int id, CancellationToken cancellationToken)
        {
            return await _service.GetCustomer(id, cancellationToken);
        }

        public async Task<ExpertDTO>? GetExpert(int id, CancellationToken cancellationToken)
        {
            return await _service.GetExpert(id, cancellationToken);
        }

        public async Task UpdateAdminProfile(AdminDTO admin, IFormFile? file, CancellationToken cancellationToken)
        {
            if (file is not null)
            {
                var ImageAddress = await _service.UploadFilePic(file, cancellationToken);
                admin.FileLocation = ImageAddress;
            }
            await _service.UpdateAdminProfile(admin, cancellationToken);
        }

        public async Task UpdateCustomerProfile(CustomerDTO customer, IFormFile? file, CancellationToken cancellationToken)
        {
            if (file is not null)
            {
                var ImageAddress = await _service.UploadFilePic(file, cancellationToken);
                customer.FileLocation = ImageAddress;
            }
            await _service.UpdateCustomerProfile(customer, cancellationToken);
        }

        public async Task UpdateExpertProfile(ExpertDTO expert,IFormFile? file,CancellationToken cancellationToken)
        {
            if (file is not null)
            {
                var ImageAddress = await _service.UploadFilePic(file, cancellationToken);
                expert.FileLocation = ImageAddress;
            }
            await _service.UpdateExpertProfile(expert, cancellationToken);
        }

        public async Task UpdateExpertSkills(int expertId, List<int> services, CancellationToken cancellationToken)
        {
            await _service.UpdateExpertSkills(expertId, services, cancellationToken);
        }
    }
}
