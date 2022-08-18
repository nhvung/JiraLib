using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class MyselfInfo
    {
        public class MyselfGroups
        {
            public int Size { get; set; }
            public object[] Items { get; set; }
        }

        public class MyselfApplicationRoles
        {
            public int Size { get; set; }
            public object[] Items { get; set; }
        }
        public string Self { get; set; }
        public string AccountId { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string TimeZone { get; set; }
        public string Locale { get; set; }
        public MyselfGroups Groups { get; set; }
        public MyselfApplicationRoles ApplicationRoles { get; set; }
        public string Expand { get; set; }
    }

    

}
