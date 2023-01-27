using Coins.Helpers.Enums;
using Coins.Models;
using Coins.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins.Services
{
    public class IssueService : IIssueService
    {
        private static readonly List<Issue> _issues = new List<Issue>
{
                        new Issue
                {
                    Title = "Safety Issue",
                    Type = IssueType.Safety
                },
                new Issue
                {
                    Title = "Electrical Issue",
                    Type = IssueType.Electrical
                },
                new Issue
                {
                    Title = "Paint Issue",
                    Type = IssueType.Paint
                },
                new Issue
                {
                    Title = "Mechanical Issue",
                    Type = IssueType.Mechanical
                },
    };
        public IssueService() 
        {

        }

        public void CreateIssue(Issue issue)
        {
            _issues.Add(issue);
        }

        public Task<List<Issue>> GetAllIssues()
        {
            throw new NotImplementedException();
        }

        public Task<Issue> GetIssue(string issueId)
        {
            throw new NotImplementedException();
        }

        public List<Issue> GetIssuesByType(IssueType type)
        {
            var issueList = new List<Issue>();

            issueList = _issues.Where(i => i.Type == type).ToList();       

            return issueList;
        }

        public List<IssueTypes> GetIssueTypesWithCount()
        {
            var issueTypes = new List<IssueTypes> {
                    new IssueTypes
                    {
                        Type = IssueType.Safety,
                        Count = 1
                    },
                    new IssueTypes
                    {
                        Type = IssueType.Paint,
                        Count = 3
                    },
                    new IssueTypes
                    {
                        Type = IssueType.Electrical,
                        Count = 1
                    },
                    new IssueTypes
                    {
                        Type = IssueType.Mechanical,
                        Count = 7
                    }
                };

            return issueTypes;
        }
    }
}
