using Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Entities
{
    public class ExpertSkill
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public Expert Expert { get; set; }
        public int ExpertId { get; set; }
    }
}
