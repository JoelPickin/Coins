using Coins.Services;
using Coins.ViewModels;
using Coins.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Coins
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/Dashboard");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Dashboard, DashboardViewModel>();
            containerRegistry.RegisterForNavigation<ViewIssue, ViewIssueViewModel>();
            containerRegistry.RegisterForNavigation<CreateIssue, CreateIssueViewModel>();
            containerRegistry.RegisterForNavigation<IssuesList, IssuesListViewModel>();

            containerRegistry.Register<IssueService>();
        }
    }
}
