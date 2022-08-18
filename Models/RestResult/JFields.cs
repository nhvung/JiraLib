using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models.RestResult
{
    public class JFields
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public JUser Reporter { get; set; }
        public JUser Assignee { get; set; }
        public JUser Creator { get; set; }
        public JIDKeyName Priority { get; set; }
        public JIDKeyName Status { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public float? Customfield_10026 { get; set; }
        public float? Customfield_10004 { get; set; }
        public string Customfield_10019 { get; set; }
        public JIDKeyName IssueType { get; set; }
        public JIDKeyName Parent { get; set; }
        public JIDKeyName Project { get; set; }
    }
}
