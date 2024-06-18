using Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public List<Request>? Requests { get; set; }
        public List<ExpertSkill>? Skills { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
