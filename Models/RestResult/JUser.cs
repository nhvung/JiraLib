using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models.RestResult
{
    public class JUser
    {

        string _AccountId;
        public string AccountId { get { return _AccountId; } set { _AccountId = value; } }

        string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; } }
        public override string ToString()
        {
            return $"{_AccountId} - {_DisplayName}";
        }
    }
}
