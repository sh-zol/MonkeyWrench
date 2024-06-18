using Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
       // public Expert Expert { get; set; }
      //  public int ExpertId { get; set; }
        public Service Service { get; set; }
        public int ServiceId {  get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
    }
}
