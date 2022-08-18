using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class StoryInfo
    {
        public IssueInfo MainTask { get; set; }
        public List<IssueInfo> SubTasks { get; set; }
        public bool HasSubTasks { get { return SubTasks?.Count > 0; } }
        public StoryInfo()
        {
            MainTask = null;
            SubTasks = new List<IssueInfo>();
        }
        public override string ToString()
        {
            return MainTask?.ToString();
        }
    }
}
