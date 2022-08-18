using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class ProjectInfo
    {
        public int ID { get; set; }
        public string Self { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string ProjectTypeKey { get; set; }
        public bool Simplified { get; set; }
        public override string ToString()
        {
            return $"{ID} - {Name}";
        }
    }
}
