using System.Collections.Generic;

namespace JiraLib.Request
{
    public class SearchTaskRequest
    {
        List<string> _Boards;
        public List<string> Boards { get { return _Boards; } set { _Boards = value; } }
        List<string> _Sprints;
        public List<string> Sprints { get { return _Sprints; } set { _Sprints = value; } }
    }
}