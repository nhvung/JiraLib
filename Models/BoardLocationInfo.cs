using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class BoardLocationInfo
    {
        public int ProjectId { get; set; }
        public string DisplayName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectKey { get; set; }
        public string ProjectTypeKey { get; set; }
        public string AvatarURI { get; set; }
        public string Name { get; set; }
    }
}
