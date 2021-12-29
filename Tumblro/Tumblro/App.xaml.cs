using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Tumblro.ViewModels;
using Tumblro.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Tumblro
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

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<BlogPosts, BlogPostsViewModel>();
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterDialog<DismissableDialog, SampleDialogViewModel>();
        }
    }
}
