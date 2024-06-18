using Domain.Core.HomeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Entities
{
    public class Expert:Person
    {
        public Expert()
        {
            Role = Enums.Role.Expert;
            Requests = new List<Request>();
            Bids = new List<Bid>();
            Skills = new List<ExpertSkill>();
        }

      //  public List<Comment>? Comments { get; set; }
        public List<Request>? Requests { get; set; }
        public List<Bid>? Bids { get; set; }
        public List<ExpertSkill>? Skills { get; set; }
    }
}
