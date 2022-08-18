using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models.RestResult
{
    public class JResponse
    {

        string _Expand;
        public string Expand { get { return _Expand; } set { _Expand = value; } }

        int _StartAt;
        public int StartAt { get { return _StartAt; } set { _StartAt = value; } }

        int _MaxResults;
        public int MaxResults { get { return _MaxResults; } set { _MaxResults = value; } }

        int _Total;
        public int Total { get { return _Total; } set { _Total = value; } }

        List<JIssue> _Issues;
        public List<JIssue> Issues { get { return _Issues; } set { _Issues = value; } }

    }
}
