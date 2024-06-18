using Domain.Core.HomeService.DTOS;
using Domain.Core.HomeService.Entities;
using Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.DTOs
{
    public class ExpertDTO:Expert
    {
        public ExpertDTO()
        {
            Services = new List<ServiceDTO>();
            ServiceIds = new List<int>();
        }
        public List<ServiceDTO>? Services {  get; set; }
        public List<int>? ServiceIds { get; set; }
    }
}
