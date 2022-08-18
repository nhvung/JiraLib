using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class SprintInfo
    {
        public int ID { get; set; }
        public string Self { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public int OriginBoardId { get; set; }
        public override string ToString()
        {
            return $"{ID} - {Name}";
        }
    }
}
