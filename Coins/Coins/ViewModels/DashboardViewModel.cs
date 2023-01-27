using Coins.Helpers.Enums;
using Coins.Models;
using Coins.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Coins.ViewModels
{
    public class DashboardViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService { get; set; }
        private IssueService _issueService { get; set; }

        public DelegateCommand<IssueTypes> IssueSelectedCommand { get; private set; }
        public List<IssueTypes> IssueTypes { get; set; }

        public DashboardViewModel(INavigationService navigationService, IssueService issueService)
        {
            _navigationService = navigationService;
            _issueService = issueService;
            IssueSelectedCommand = new DelegateCommand<IssueTypes>(OnIssueSelected);
            IssueTypes = _issueService.GetIssueTypesWithCount();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        private void OnIssueSelected(IssueTypes issueType)
        {
            var navigationParams = new NavigationParameters
            {
                {"IssueType", issueType.Type }
            };

            _navigationService.NavigateAsync("IssuesList", navigationParams);
        }
    }
}
