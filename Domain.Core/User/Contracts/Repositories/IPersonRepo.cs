using Domain.Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Contracts.Repositories
{
    public interface IPersonRepo
    {
        public Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken);
        public Task<CustomerDTO>? GetCustomer(int id, CancellationToken cancellationToken);
        public Task<ExpertDTO>? GetExpert(int id, CancellationToken cancellationToken);
        public Task UpdateExpertProfile(ExpertDTO expert, CancellationToken cancellationToken);
        public Task UpdateCustomerProfile(CustomerDTO customer, CancellationToken cancellationToken);
        public Task UpdateAdminProfile(AdminDTO admin, CancellationToken cancellationToken);
        Task UpdateExpertSkills(int expertId, List<int> services, CancellationToken cancellationToken);
    }
}
