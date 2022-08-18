using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class EpicInfo
    {
        public int id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public bool done { get; set; }

        public override string ToString()
        {
            return $"{key} - {name}";
        }
    }
}
