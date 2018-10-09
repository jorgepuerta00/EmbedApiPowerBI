using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.DTO
{
    public class TokenRequest
    {
        public string GroupId { get; set; }
        public string ReportId { get; set; }
        public string DatasetId { get; set; }
        public string AccessLevel { get; set; }
    }
}
