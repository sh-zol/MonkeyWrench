﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.HomeService.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Massage {  get; set; }
        public Request? Request { get; set; }
        public int? RequestId { get; set; }
    }
}
