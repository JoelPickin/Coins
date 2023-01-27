using Coins.Helpers.Enums;
using Coins.Models;
using Coins.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coins.Services
{
    interface IIssueService
    {
        void CreateIssue(Issue issue);
        Task<Issue> GetIssue(string issueId);
        Task<List<Issue>> GetAllIssues();
        List<Issue> GetIssuesByType(IssueType type);
        List<IssueTypes> GetIssueTypesWithCount();
    }
}
