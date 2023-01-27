using Coins.Helpers.Enums;
using Coins.Models;
using Coins.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Coins.ViewModels
{
    public class IssuesListViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService { get; set; }
        private IssueService _issueService { get; set; }
        public DelegateCommand NavigateToCreatePageCommand { get; set; }
        public List<Issue> Issues { get; set; } = new List<Issue>();

        public IssuesListViewModel(INavigationService navigationService, IssueService issueService)
        {
            _navigationService = navigationService;
            _issueService = issueService;
            NavigateToCreatePageCommand = new DelegateCommand(NavigateToCreatePage);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void Initialize(INavigationParameters parameters)
        {


        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var issueType = parameters.GetValue<IssueType>("IssueType");

            Issues = _issueService.GetIssuesByType(issueType);
        }

        public void NavigateToCreatePage()
        {
            _navigationService.NavigateAsync("CreateIssue");
        }
    }
}
