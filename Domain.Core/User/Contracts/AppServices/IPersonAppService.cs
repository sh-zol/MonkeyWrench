using Domain.Core.User.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Contracts.AppServices
{
    public interface IPersonAppService
    {
        public Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken);
        public Task<CustomerDTO>? GetCustomer(int id, CancellationToken cancellationToken);
        public Task<ExpertDTO>? GetExpert(int id, CancellationToken cancellationToken);
        public Task UpdateExpertProfile(ExpertDTO expert,IFormFile? file,CancellationToken cancellationToken);
        public Task UpdateCustomerProfile(CustomerDTO customer,IFormFile? file, CancellationToken cancellationToken);
        public Task UpdateAdminProfile(AdminDTO admin,IFormFile? file,CancellationToken cancellationToken);
        Task UpdateExpertSkills(int expertId, List<int> services, CancellationToken cancellationToken);
    }
}
