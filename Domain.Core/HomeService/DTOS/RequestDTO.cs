using Domain.Core.HomeService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.DTOS
{
    public class RequestDTO:Request
    {
        public string? ExpertName { get; set; }
        public string? CustomerName { get; set; }
        public string? StatusTitle { get; set; }
        public List<BidDTO>? BidDTOs { get; set; }
        public List<CommentDTO>? CommentDTOs { get; set; }
    }
}
