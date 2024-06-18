using Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("توضیحات پیشنهاد")]
        public string Description { get; set; }
        [Required]
        [DisplayName("تاریخ انجام")]
        public DateTime DeadLine { get; set; }
        [Required]
        [DisplayName("قیمت پیشنهادی")]
        public int Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Expert Expert { get; set; }
        public int ExpertId { get; set; }
        public bool IsAccepted { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }

    }
}
