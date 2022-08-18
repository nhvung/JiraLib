using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models.RestResult
{
    public class JIDKeyName
    {
        int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        string _Key;
        public string Key { get { return _Key; } set { _Key = value; } }

        string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        public override string ToString()
        {
            return $"{_ID} - {_Name}";
        }
    }
}
