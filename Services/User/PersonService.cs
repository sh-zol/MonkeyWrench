using Domain.Core.User.Contracts.Repositories;
using Domain.Core.User.Contracts.Services;
using Domain.Core.User.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepo _repo;

        public PersonService(IPersonRepo repo)
        {
            _repo = repo;
        }

        public async Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetAdmin(id, cancellationToken);
        }

        public async Task<CustomerDTO>? GetCustomer(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetCustomer(id, cancellationToken);
        }

        public async Task<ExpertDTO>? GetExpert(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetExpert(id, cancellationToken);
        }

        public async Task UpdateAdminProfile(AdminDTO admin, CancellationToken cancellationToken)
        {
            await _repo.UpdateAdminProfile(admin, cancellationToken);
        }

        public async Task UpdateCustomerProfile(CustomerDTO customer, CancellationToken cancellationToken)
        {
            await _repo.UpdateCustomerProfile(customer, cancellationToken);
        }

        public async Task UpdateExpertProfile(ExpertDTO expert, CancellationToken cancellationToken)
        {
            await _repo.UpdateExpertProfile(expert, cancellationToken);
        }

        public async Task UpdateExpertSkills(int expertId, List<int> services, CancellationToken cancellationToken)
        {
            await _repo.UpdateExpertSkills(expertId, services, cancellationToken);
        }
        public async Task<string> UploadFilePic(IFormFile file, CancellationToken cancellationToken)
        {
            string filepath;
            string filename;
            if (file != null)
            {
                filename = Guid.NewGuid().ToString() +
                    ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                filepath = Path.Combine("wwwroot/Images", filename);
                try
                {
                    using (var stream = System.IO.File.Create(filepath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch
                {
                    throw new Exception("upload failed");
                }
                return $"/Images/{filename}";
            }
            else filename = "";
            return filename;
        }
    }
}
