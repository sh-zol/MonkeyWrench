using Domain.Core.HomeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.DTOS
{
    public class BidDTO:Bid
    {
        public string? ExpertName {  get; set; } 
    }
}
