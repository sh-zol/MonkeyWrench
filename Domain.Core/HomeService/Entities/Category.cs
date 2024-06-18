using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Entities
{
    public class Category
    {
        public Category()
        {
            Services = new List<Service>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Service>? Services { get; set; }
        public bool IsActive { get; set; }
    }
}
