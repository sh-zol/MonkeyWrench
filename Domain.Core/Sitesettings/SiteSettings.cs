using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Sitesettings
{
    public class SiteSettings
    {
        public LogConfig LogConfig { get; set; }
        public SqlConfig SqlConfig { get; set; }
    }
}
