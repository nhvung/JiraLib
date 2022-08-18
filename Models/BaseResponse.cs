using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class BaseResponse<TInfo>
    {
        public int MaxResults { get; set; }
        public int StartAt { get; set; }
        public bool IsLast { get; set; }
        public List<TInfo> Values { get; set; }
        public int Total { get; set; }
    }
}
