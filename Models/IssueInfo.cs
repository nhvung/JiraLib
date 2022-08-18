using System;
using System.Collections.Generic;
using System.Text;

namespace Jira.Models
{
    public class IssueInfo
    {
        public string Key { get; set; }
        public string PKey { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }
        public string Project { get; set; }
        public string Reporter { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string OriginalEstimate { get; set; }
        public int OriginalEstimateInSeconds { get; set; }
        public string RemainingEstimate { get; set; }
        public int RemainingEstimateInSeconds { get; set; }
        public string TimeSpent { get; set; }
        public int TimeSpentInSeconds { get; set; }
        public float StoryPoints { get; set; }
        public string Type { get; set; }
        public string RankValue { get; set; }

        public IssueInfo()
        { }
        public IssueInfo(RestResult.JIssue issue)
        {
            Key = issue.Key;
            PKey = issue.Fields?.Parent?.Key ?? "";
            Summary = issue.Fields.Summary;
            Assignee = issue.Fields?.Assignee?.DisplayName ?? "Unassigned";
            Project = issue.Fields?.Project?.Key;
            Reporter = issue.Fields?.Reporter?.AccountId;
            Description = issue.Fields?.Description;
            CreatedTime = issue.Fields?.Created ?? DateTime.MinValue;
            //DueTime = issue.DueDate ?? DateTime.MinValue;
            UpdatedTime = issue.Fields?.Updated ?? DateTime.MinValue;
            Status = issue.Fields?.Status?.Name;
            //OriginalEstimate = issue.TimeTrackingData.OriginalEstimate ?? "-";
            //OriginalEstimateInSeconds = issue.TimeTrackingData.OriginalEstimateInSeconds ?? 0;
            //RemainingEstimate = issue.TimeTrackingData.RemainingEstimate ?? "-";
            //RemainingEstimateInSeconds = issue.TimeTrackingData.RemainingEstimateInSeconds ?? 0;
            //TimeSpent = issue.TimeTrackingData.TimeSpent ?? "-";
            //TimeSpentInSeconds = issue.TimeTrackingData.TimeSpentInSeconds ?? 0;
            Priority = issue.Fields?.Priority?.Name;
            StoryPoints = issue.Fields?.Customfield_10026 ?? 0;
            RankValue = issue.Fields?.Customfield_10019 ?? string.Empty;
            Type = issue.Fields?.IssueType?.Name;
        }

        public override string ToString()
        {
            return $"{Key} / {PKey}: {Summary}";
        }
    }
}
