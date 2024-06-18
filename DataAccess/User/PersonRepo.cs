using DataBase.Context;
using Domain.Core.HomeService.Entities;
using Domain.Core.User.Contracts.Repositories;
using Domain.Core.User.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.User
{
    public class PersonRepo : IPersonRepo
    {
        private readonly AppDBContext _context;
        private readonly ILogger<PersonRepo> _logger;
        public PersonRepo(AppDBContext appDBContext,
            ILogger<PersonRepo> logger)
        {
            _context = appDBContext;
            _logger = logger;
        }
        public async Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken)
        {
          //  var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            var admin = await _context.Admins
                .Include(x=>x.AppUser)
                .Where(x => x.AppUser.Id == id).Select(x => new AdminDTO
            {
                Id = x.Id,
                AboutMe = x.AboutMe,
                Address = x.Address,
                Email = x.Email,
                File = x.File,
                FullName = x.FullName,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                FileLocation = x.FileLocation,
            }).FirstOrDefaultAsync(cancellationToken);
            return admin ?? new AdminDTO();
        }

        public async Task<CustomerDTO>? GetCustomer(int id, CancellationToken cancellationToken)
        {
           // var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            var customer = await _context.Customers
                .Include(x=>x.AppUser)
                .Where(x => x.AppUser.Id == id).Select(x => new CustomerDTO
            {
                Id = x.Id,
                AboutMe = x.AboutMe,
                Address = x.Address,
                Comments = x.Comments,
                Email = x.Email,
                File = x.File,
                FullName = x.FullName,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                FileLocation = x.FileLocation,
                Requests = x.Requests
            }).FirstOrDefaultAsync(cancellationToken);
            return customer ?? new CustomerDTO();
        }

        public async Task<ExpertDTO>? GetExpert(int id, CancellationToken cancellationToken)
        {
           // var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            var expert = await _context.Experts
                .Include(x => x.AppUser)
                .Where(x => x.AppUser.Id == id).Select(x => new ExpertDTO
            {
                Id = x.Id,
                AboutMe = x.AboutMe,
                Address = x.Address,
                Email = x.Email,
                File = x.File,
                FullName = x.FullName,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                Bids = x.Bids,
                FileLocation = x.FileLocation,
                Requests = x.Requests,
                Skills = x.Skills,
            }).FirstOrDefaultAsync(cancellationToken);
            return expert ?? new ExpertDTO();
        }

        public async Task UpdateAdminProfile(AdminDTO admin, CancellationToken cancellationToken)
        {
            var vm = await _context.Admins.FirstOrDefaultAsync(x => x.Id == admin.Id, cancellationToken);
            if (vm != null)
            {
                vm.FullName = admin.FullName;
                vm.Address = admin.Address;
                vm.PhoneNumber = admin.PhoneNumber;
                vm.Email = admin.Email;
                vm.AboutMe = admin.AboutMe;
                vm.Password = admin.Password;
                vm.FileLocation = admin.FileLocation;
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCustomerProfile(CustomerDTO customer, CancellationToken cancellationToken)
        {
            var vm = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id, cancellationToken);
            if (vm != null)
            {
                vm.FullName = customer.FullName;
                vm.Email = customer.Email;
                vm.AboutMe = customer.AboutMe;
                vm.Address = customer.Address;
                vm.Password = customer.Password;
                vm.PhoneNumber = customer.PhoneNumber;
                vm.FileLocation = customer.FileLocation;
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateExpertProfile(ExpertDTO expert, CancellationToken cancellationToken)
        {
            var expertvm = await _context.Experts
               .FirstOrDefaultAsync(x => x.Id == expert.Id, cancellationToken);
            if (expertvm != null)
            {
                expertvm.FullName = expert.FullName;
                expertvm.Address = expert.Address;
                expertvm.PhoneNumber = expert.PhoneNumber;
                expertvm.AboutMe = expert.AboutMe;
                expertvm.Email = expert.Email;
                expertvm.Password = expert.Password;
                expertvm.FileLocation = expert.FileLocation;
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateExpertSkills(int expertId, List<int> services, CancellationToken cancellationToken)
        {
            var result = await _context.ExpertSkills.Where(x=>x.ExpertId == expertId).ToListAsync(cancellationToken);
            foreach(var service in result)
            {
                _context.ExpertSkills.Remove(service);
            }
            foreach(var service in services)
            {
                ExpertSkill skill = new ExpertSkill()
                {
                    ExpertId = expertId,
                    ServiceId = service,
                };
                await _context.ExpertSkills.AddAsync(skill, cancellationToken);
                _logger.LogInformation("skills has been added to expert");
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
