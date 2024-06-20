using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Address { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? FileLocation { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public int? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeadLine {  get; set; }
        public string? DeadLineFa {  get; set; }
        public string? CreatedDateFa {  get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Expert? Expert { get; set; }
        public int? ExpertId { get; set; }
        public Status? Status { get; set; }
        public int? StatusId { get; set; }
        public List<Comment>? Comments { get; set; }
        //public int CommentId { get; set; }
        public List<Bid>? Bids { get; set; }
    }
}
