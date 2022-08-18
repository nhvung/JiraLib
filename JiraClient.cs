using Jira.Models;
using Jira.Models.RestResult;
using JiraLib.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jira
{
    public class JiraClient
    {
        const string _CT_JSON = "application/json";
        string _url;
        string _credentials;
        public JiraClient(string url, string username, string jiraToken)
        {
            _url = url;
            while (_url.EndsWith("/"))
            {
                _url = _url.Substring(0, _url.Length - 1);
            }
            if (_url.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            }
            var mergedCredentials = string.Format("{0}:{1}", username, jiraToken);
            var byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
            _credentials = Convert.ToBase64String(byteCredentials);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        public async Task<List<BoardInfo>> GetBoardsAsync(params string[] pNames)
        {
            try
            {
                string requestUrl = string.Format("{0}/rest/agile/1.0/board", _url);
                int startAt = 0;
                BaseResponse<BoardInfo> jRes = new BaseResponse<BoardInfo>();
                List<BoardInfo> boards = new List<BoardInfo>();
                KeyValuePair<string, string>[] additionalHeaders = new KeyValuePair<string, string>[] {
                    new KeyValuePair<string,string>("Authorization", "Basic " + _credentials)
                };

                do
                {
                    string url = string.Format("{0}?startAt={1}&maxResults=100", requestUrl, startAt);
                    var getResult = await this.GetDataAsync(url, 3600, _CT_JSON, true, additionalHeaders);
                    if (getResult.StatusCode == HttpStatusCode.OK)
                    {
                        string response = await getResult.ToStringAsync(Encoding.UTF8);
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            break;
                        }
                        jRes = JsonConvert.DeserializeObject<BaseResponse<BoardInfo>>(response);
                        if (jRes == null)
                        {
                            break;
                        }
                        boards.AddRange(jRes.Values);
                        startAt += jRes.Values.Count;
                    }
                }
                while (!jRes.IsLast || boards.Count < jRes.Total);
                return boards;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SprintInfo>> GetSprintsAsync(int boardId)
        {
            try
            {
                string requestUrl = string.Format("{0}/rest/agile/1.0/board/{1}/sprint", _url, boardId);

                int startAt = 0;
                BaseResponse<SprintInfo> jRes = new BaseResponse<SprintInfo>();
                List<SprintInfo> sprints = new List<SprintInfo>();
                KeyValuePair<string, string>[] additionalHeaders = new KeyValuePair<string, string>[] {
                    new KeyValuePair<string,string>("Authorization", "Basic " + _credentials)
                };
                do
                {
                    string url = string.Format("{0}?startAt={1}&maxResults=100", requestUrl, startAt);
                    var getResult = await this.GetDataAsync(url, 3600, _CT_JSON, true, additionalHeaders);
                    if (getResult.StatusCode == HttpStatusCode.OK)
                    {
                        string response = await getResult.ToStringAsync(Encoding.UTF8);
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            break;
                        }
                        jRes = JsonConvert.DeserializeObject<BaseResponse<SprintInfo>>(response);
                        if (jRes == null)
                        {
                            break;
                        }
                        sprints.AddRange(jRes.Values);
                        startAt += jRes.Values.Count;
                    }
                }
                while (!jRes.IsLast);

                return sprints;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<EpicInfo>> GetEpicsAsync(int boardId)
        {
            try
            {
                string requestUrl = string.Format("{0}/rest/agile/1.0/board/{1}/epic", _url, boardId);
                int startAt = 0;
                BaseResponse<EpicInfo> jRes = new BaseResponse<EpicInfo>();
                List<EpicInfo> epics = new List<EpicInfo>();
                KeyValuePair<string, string>[] additionalHeaders = new KeyValuePair<string, string>[] {
                    new KeyValuePair<string,string>("Authorization", "Basic " + _credentials)
                };
                do
                {
                    string url = string.Format("{0}?startAt={1}&maxResults=100", requestUrl, startAt);
                    var getResult = await this.GetDataAsync(url, 3600, _CT_JSON, true, additionalHeaders);
                    if (getResult.StatusCode == HttpStatusCode.OK)
                    {
                        string response = await getResult.ToStringAsync(Encoding.UTF8);
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            break;
                        }
                        jRes = JsonConvert.DeserializeObject<BaseResponse<EpicInfo>>(response);
                        if (jRes == null)
                        {
                            break;
                        }
                        epics.AddRange(jRes.Values);
                        startAt += jRes.Values.Count;
                    }
                }
                while (!jRes.IsLast);
                return epics;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProjectInfo>> GetProjectsAsync(int boardId)
        {
            List<ProjectInfo> projects = new List<ProjectInfo>();
            try
            {
                string requestUrl = string.Format("{0}/rest/agile/1.0/board/{1}/project", _url, boardId);

                int startAt = 0;
                BaseResponse<ProjectInfo> jRes = new BaseResponse<ProjectInfo>();
                KeyValuePair<string, string>[] additionalHeaders = new KeyValuePair<string, string>[] {
                    new KeyValuePair<string,string>("Authorization", "Basic " + _credentials)
                };
                do
                {
                    string url = string.Format("{0}?startAt={1}&maxResults=100", requestUrl, startAt);
                    var getResult = await this.GetDataAsync(url, 3600, _CT_JSON, true, additionalHeaders);
                    if (getResult.StatusCode == HttpStatusCode.OK)
                    {
                        string response = await getResult.ToStringAsync(Encoding.UTF8);
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            break;
                        }
                        jRes = JsonConvert.DeserializeObject<BaseResponse<ProjectInfo>>(response);
                        if (jRes == null)
                        {
                            break;
                        }
                        projects.AddRange(jRes.Values);
                        startAt += jRes.Values.Count;
                    }
                }
                while (!jRes.IsLast);
                return projects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<IssueInfo>> GetTaskByKeysAsync(List<string> keys)
        {
            List<IssueInfo> issuses = new List<IssueInfo>();
            try
            {
                if (keys?.Count > 0)
                {
                    string jql = string.Format("IssueKey in ({0})", string.Join(",", keys));

                    string requestUrl = string.Format("{0}/rest/api/2/search", _url);
                    JResponse jRes = new JResponse();
                    KeyValuePair<string, string>[] additionalHeaders = new KeyValuePair<string, string>[] {
                        new KeyValuePair<string,string>("Authorization", "Basic " + _credentials)
                    };
                    int iCount = 0;
                    do
                    {
                        string url = string.Format("{0}?jql={1}&startAt={2}&maxResults=100", requestUrl, jql, iCount);
                        var getResult = await this.GetDataAsync(url, 3600, _CT_JSON, true, additionalHeaders);
                        if (getResult.StatusCode == HttpStatusCode.OK)
                        {
                            string response = await getResult.ToStringAsync(Encoding.UTF8);
                            if (string.IsNullOrWhiteSpace(response))
                            {
                                break;
                            }
                            jRes = JsonConvert.DeserializeObject<JResponse>(response);
                            if (jRes == null)
                            {
                                break;
                            }

                            foreach (var issue in jRes.Issues)
                            {
                                try
                                {
                                    IssueInfo issueInfo = new IssueInfo(issue);
                                    issuses.Add(issueInfo);
                                }
                                catch //(Exception ex)
                                {
                                }
                                iCount++;
                            }
                        }
                    }
                    while (iCount < jRes.Total);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return issuses;
        }

        public async Task<List<StoryInfo>> GetStoryInSprintAsync(int sprint_ID, List<string> projectKeys, List<string> statuses, bool includeSubTasks = false)
        {
            try
            {
                string requestUrl = string.Format("{0}/rest/api/2/search", _url);

                List<string> filterObjs = new List<string>();

                filterObjs.Add("sprint=" + sprint_ID);

                string ftProject = projectKeys?.Count > 0 ? "project in (" + string.Join(", ", projectKeys.Select(ite => "'" + ite + "'")) + ")" : "";
                if (!string.IsNullOrWhiteSpace(ftProject))
                {
                    filterObjs.Add(ftProject);
                }

                string ftStatus = statuses?.Count > 0 ? "status in (" + string.Join(", ", statuses.Select(ite => "'" + ite + "'")) + ")" : "";
                if (!string.IsNullOrWhiteSpace(ftStatus))
                {
                    filterObjs.Add(ftStatus);
                }

                //string ftSubTask = includeSubTasks ? "issuetype in (subTaskIssueTypes(), epic)" : "issuetype not in (subTaskIssueTypes(), epic)";
                //if (!string.IsNullOrWhiteSpace(ftSubTask))
                //{
                //    filterObjs.Add(ftSubTask);
                //}
#if FOR_EIQ
                string status = onlyNewTask ? "'open', 'reopened', 'in progress', 'to do'" : "'open', 'reopened', 'in progress', 'resolved', 'closed', 'to do', 'done'";
#elif FOR_VV
                string status = onlyNewTask ? "'open', 'reopened', 'in progress', 'to do'" : "'open', 'reopened', 'in progress', 'closed', 'to do', 'dev complete'";
#endif

                string query = filterObjs?.Count > 0 ? string.Join(" and ", filterObjs) : "";
                query += " order by rank asc";

                KeyValuePair<string, string>[] additionalHeaders = new KeyValuePair<string, string>[] {
                    new KeyValuePair<string,string>("Authorization", "Basic " + _credentials)
                };
                JResponse jRes = new JResponse();
                List<IssueInfo> issuses = new List<IssueInfo>();
                int iCount = 0;
                do
                {
                    string url = string.Format("{0}?jql={1}&startAt={2}&maxResults=100", requestUrl, query, iCount);
                    var getResult = await this.GetDataAsync(url, 3600, _CT_JSON, true, additionalHeaders);
                    if (getResult.StatusCode == HttpStatusCode.OK)
                    {
                        string response = await getResult.ToStringAsync(Encoding.UTF8);
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            break;
                        }
                        jRes = JsonConvert.DeserializeObject<JResponse>(response);
                        if (jRes == null)
                        {
                            break;
                        }

                        foreach (var issue in jRes.Issues)
                        {
                            try
                            {
                                IssueInfo issueInfo = new IssueInfo(issue);
                                issuses.Add(issueInfo);
                            }
                            catch //(Exception ex)
                            {
                            }
                            iCount++;
                        }
                    }
                }
                while (iCount < jRes.Total);

                var allUssueKeys = issuses.Select(ite => ite.Key).ToArray();
                var pKeyObjs = issuses?.Where(ite => ite.Type.Equals("Sub-task", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrWhiteSpace(ite.PKey)
               && !allUssueKeys.Contains(ite.PKey, StringComparer.InvariantCultureIgnoreCase)
               )
                   ?.Select(ite => ite.PKey)?.Distinct(StringComparer.InvariantCultureIgnoreCase)?.ToList();
                if (pKeyObjs?.Count > 0)
                {
                    var pIssueObjs = await GetTaskByKeysAsync(pKeyObjs);
                    if (pIssueObjs?.Count > 0)
                    {
                        foreach (var pIssueInfoObj in pIssueObjs)
                        {
                            pIssueInfoObj.PKey = string.Empty;
                            issuses.Add(pIssueInfoObj);
                        }
                    }
                }

                Dictionary<string, StoryInfo> m_story = new Dictionary<string, StoryInfo>(StringComparer.InvariantCultureIgnoreCase);
                foreach (var issue in issuses.Where(ite => ite.Type.Equals("story", StringComparison.InvariantCultureIgnoreCase) || ite.Type.Equals("task", StringComparison.InvariantCultureIgnoreCase)))
                {
                    m_story[issue.Key] = new StoryInfo() { MainTask = issue, SubTasks = new List<IssueInfo>() };
                }
                foreach (var issue in issuses.Where(ite => ite.Type.Equals("sub-task", StringComparison.InvariantCultureIgnoreCase)))
                {
                    try
                    {
                        if (m_story.ContainsKey(issue.PKey))
                        {
                            m_story[issue.PKey].SubTasks.Add(issue);
                        }
                    }
                    catch
                    {

                    }
                }

                return m_story.Values.OrderBy(ite => ite.MainTask.RankValue, StringComparer.InvariantCultureIgnoreCase).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MyselfInfo> GetLoginInfoAsync()
        {
            MyselfInfo result = default;
            try
            {
                string requestUrl = string.Format("{0}/rest/api/2/myself", _url);

                using (WebClient webClient = new WebClient())
                {
                    string url = string.Format("{0}", requestUrl);
                    webClient.Headers.Set("Authorization", "Basic " + _credentials);
                    webClient.Encoding = Encoding.UTF8;
                    string response = await webClient.DownloadStringTaskAsync(url);
                    result = JsonConvert.DeserializeObject<MyselfInfo>(response);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<List<StoryInfo>>
        GetStoryInTimeframeAsync(List<int> sprint_IDs, List<string> projectKeys, List<string> types
        , DateTime createdDateTimeFrom, DateTime createdDateTimeTo
        , DateTime updatedDateTimeFrom, DateTime updatedDateTimeTo
        , List<string> statuses, bool includeSubTasks = false
        , Action<string> debugLog = null)
        {
            try
            {
                string requestUrl = string.Format("{0}/rest/api/2/search", _url);

                List<string> filterObjs = new List<string>();

                if (sprint_IDs?.Count > 0)
                {
                    filterObjs.Add($"sprint in({string.Join(",", sprint_IDs)})");
                }

                string ftProject = projectKeys?.Count > 0 ? "project in (" + string.Join(", ", projectKeys.Select(ite => "'" + ite + "'")) + ")" : "";
                if (!string.IsNullOrWhiteSpace(ftProject))
                {
                    filterObjs.Add(ftProject);
                }

                string ftStatus = statuses?.Count > 0 ? "status in (" + string.Join(", ", statuses.Select(ite => "'" + ite + "'")) + ")" : "";
                if (!string.IsNullOrWhiteSpace(ftStatus))
                {
                    filterObjs.Add(ftStatus);
                }
#if FOR_EIQ
                string status = onlyNewTask ? "'open', 'reopened', 'in progress', 'to do'" : "'open', 'reopened', 'in progress', 'resolved', 'closed', 'to do', 'done'";
#elif FOR_VV
                string status = onlyNewTask ? "'open', 'reopened', 'in progress', 'to do'" : "'open', 'reopened', 'in progress', 'closed', 'to do', 'dev complete'";
#endif

                string ftType = types?.Count > 0 ? "issuetype in (" + string.Join(", ", types.Select(ite => "'" + ite + "'")) + ")" : "";
                if (!string.IsNullOrWhiteSpace(ftType))
                {
                    filterObjs.Add(ftType);
                }

                List<string> timeFts = new List<string>();
                if (createdDateTimeFrom > DateTime.MinValue)
                {
                    timeFts.Add($"created >= \"{createdDateTimeFrom.ToString("yyyy-MM-dd HH:mm")}\"");
                }
                if (createdDateTimeTo > DateTime.MinValue)
                {
                    timeFts.Add($"created <= \"{createdDateTimeTo.ToString("yyyy-MM-dd HH:mm")}\"");
                }
                if (updatedDateTimeFrom > DateTime.MinValue)
                {
                    timeFts.Add($"updated >= \"{updatedDateTimeFrom.ToString("yyyy-MM-dd HH:mm")}\"");
                }
                if (updatedDateTimeTo > DateTime.MinValue)
                {
                    timeFts.Add($"updated <= \"{updatedDateTimeTo.ToString("yyyy-MM-dd HH:mm")}\"");
                }
                if (timeFts.Count > 0)
                {
                    filterObjs.Add(string.Join(" and ", timeFts));
                }

                string query = filterObjs?.Count > 0 ? string.Join(" and ", filterObjs) : "";
                query += " order by rank asc";

                JResponse jRes = new JResponse();
                List<IssueInfo> issuses = new List<IssueInfo>();
                KeyValuePair<string, string>[] additionalHeaders = new KeyValuePair<string, string>[] {
                    new KeyValuePair<string,string>("Authorization", "Basic " + _credentials)
                };
                int iCount = 0;
                do
                {
                    string url = string.Format("{0}?jql={1}&startAt={2}&maxResults=100", requestUrl, query, iCount);
                    var getResult = await this.GetDataAsync(url, 3600, _CT_JSON, true, additionalHeaders);
                    if (getResult.StatusCode == HttpStatusCode.OK)
                    {
                        string response = await getResult.ToStringAsync(Encoding.UTF8);
                        if (string.IsNullOrWhiteSpace(response))
                        {
                            break;
                        }
                        jRes = JsonConvert.DeserializeObject<JResponse>(response);
                        if (jRes == null)
                        {
                            break;
                        }

                        foreach (var issue in jRes.Issues)
                        {
                            try
                            {
                                IssueInfo issueInfo = new IssueInfo(issue);
                                issuses.Add(issueInfo);
                            }
                            catch //(Exception ex)
                            {
                            }
                            iCount++;
                        }
                    }

                    debugLog?.Invoke($"Retrieving tasks status: {iCount}/{jRes.Total} {(iCount * 100.0d / jRes.Total).ToString("00.00")}%");
                }
                while (iCount < jRes.Total);

                var allUssueKeys = issuses.Select(ite => ite.Key).ToArray();
                var pKeyObjs = issuses?.Where(ite => (ite.Type.Equals("Sub-task", StringComparison.InvariantCultureIgnoreCase)) && !string.IsNullOrWhiteSpace(ite.PKey)
                && !allUssueKeys.Contains(ite.PKey, StringComparer.InvariantCultureIgnoreCase)
               )
                   ?.Select(ite => ite.PKey)?.Distinct(StringComparer.InvariantCultureIgnoreCase)?.ToList();
                if (pKeyObjs?.Count > 0)
                {
                    var pIssueObjs = await GetTaskByKeysAsync(pKeyObjs);
                    if (pIssueObjs?.Count > 0)
                    {
                        foreach (var pIssueInfoObj in pIssueObjs)
                        {
                            pIssueInfoObj.PKey = string.Empty;
                            issuses.Add(pIssueInfoObj);
                        }
                    }
                }

                Dictionary<string, StoryInfo> m_story = new Dictionary<string, StoryInfo>(StringComparer.InvariantCultureIgnoreCase);

                foreach (var issue in issuses.Where(ite => ite.Type.Equals("story", StringComparison.InvariantCultureIgnoreCase)
                || ite.Type.Equals("task", StringComparison.InvariantCultureIgnoreCase)
                || ite.Type.Equals("bug", StringComparison.InvariantCultureIgnoreCase)))
                {
                    if (types == null || types.Count == 0 || types.Contains(issue.Type, StringComparer.InvariantCultureIgnoreCase))
                    {
                        m_story[issue.Key] = new StoryInfo() { MainTask = issue, SubTasks = new List<IssueInfo>() };
                    }
                }
                foreach (var issue in issuses.Where(ite => ite.Type.Equals("sub-task", StringComparison.InvariantCultureIgnoreCase)))
                {
                    try
                    {
                        if (m_story.ContainsKey(issue.PKey))
                        {
                            m_story[issue.PKey].SubTasks.Add(issue);
                        }
                    }
                    catch
                    {

                    }
                }

                return m_story.Values.OrderBy(ite => ite.MainTask.RankValue, StringComparer.InvariantCultureIgnoreCase).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
