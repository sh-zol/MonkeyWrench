using Domain.Core.HomeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Entities
{
    public class Customer:Person
    {
        public Customer()
        {
            Role = Enums.Role.Admin;

        }
        
        public List<Comment>? Comments { get; set; }
        public List<Request>? Requests { get; set; }
    }
}
