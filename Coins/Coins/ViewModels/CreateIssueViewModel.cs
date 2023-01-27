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

namespace Coins.ViewModels
{
    public class CreateIssueViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService { get; set; }
        private IssueService _issueService { get; set; }

        public List<IssueType> IssueTypes { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public IssueType IssueType { get; set; }
        public string ContactNumber { get; set; }
        public List<string> Pictures { get; set; }
        public HighVoltage HighVoltage { get; set; }
        public RepairType RepairType { get; set; }
        public DelegateCommand<string> HighVoltageSelectedCommand { get; set; }
        public DelegateCommand<string> RepairTypeSelectedCommand { get; set; }
        public DelegateCommand CreateIssueCommand { get; set; }

        public CreateIssueViewModel(INavigationService navigationService, IssueService issueService)
        {
            IssueTypes = new List<IssueType>
            {
                IssueType.Safety,
                IssueType.Electrical,
                IssueType.Paint,
                IssueType.Mechanical
            };

            DueDate = DateTime.Today;

            HighVoltageSelectedCommand = new DelegateCommand<string>(SelectVoltage);
            RepairTypeSelectedCommand = new DelegateCommand<string>(SelectRepairType);
            CreateIssueCommand = new DelegateCommand(CreateIssue);

            _navigationService = navigationService;
            _issueService = issueService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void CreateIssue()
        {
            IssueValidation validation = IssueValidation();

            if (validation.IsValid)
            {
                var newIssue = new Issue
                {
                    Title = Title,
                    Description = Description,
                    DueDate = DueDate,
                    Status = Status,
                    Type = IssueType,
                    ContactNumber = ContactNumber,
                    Pictures= Pictures,
                    HighVoltage = HighVoltage,
                    RepairType = RepairType
                };

                _issueService.CreateIssue(newIssue);

                var navigationParams = new NavigationParameters
                {
                    {"IssueType", IssueType }
                };
       
                _navigationService.GoBackAsync(navigationParams);
            }
        }

        public IssueValidation IssueValidation()
        {
            IssueValidation validation = new IssueValidation();

            if (string.IsNullOrEmpty(Title))
            {
                validation.Message = "Title is empty";
            }
            else if (string.IsNullOrEmpty(Description))
            {
                validation.Message = "No description entered";
            }
            else if (DueDate.Date < DateTime.Today.Date)
            {
                validation.Message = "Due date is in the past";
            }
            else
            {
                validation.IsValid = true;
            }

            return validation;
        }

        private void SelectVoltage(string voltage)
        {
            if (voltage == HighVoltage.Yes.ToString())
            {
                HighVoltage = HighVoltage.Yes;
            }
            else
            {
                HighVoltage = HighVoltage.No;
            }
        }

        private void SelectRepairType(string repairType)
        {
            if (repairType == Helpers.Enums.RepairType.Service.ToString())
            {
                RepairType = RepairType.Service;
            }
            else
            {
                RepairType = RepairType.Replacement;
            }
        }
    }
}
