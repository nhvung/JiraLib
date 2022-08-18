using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models.RestResult
{
    public class JIssue
    {
        public string Expand { get; set; }
        public int ID { get; set; }

        public string Self { get; set; }
        public string Key { get; set; }
        public JFields Fields { get; set; }
    }
}
