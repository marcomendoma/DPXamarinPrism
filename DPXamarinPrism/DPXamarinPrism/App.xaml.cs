using Prism.Unity;
using DPXamarinPrism.Views;
using DPXamarin.Core.Services;

namespace DPXamarinPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("ShowPersonagem");
        }

        protected override async void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<DetailsPersonagem>();
            Container.RegisterTypeForNavigation<ShowPersonagem>();
            Container.RegisterType<ITsApiService, TsApiService>();
        }
    }
}
