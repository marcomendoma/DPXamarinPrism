using Prism.Unity;
using DPXamarinPrism.Views;
using DPXamarin.Core.Services;
using Microsoft.Practices.Unity;

namespace DPXamarinPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("ShowPersonagem");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<DetailsPersonagem>();
            Container.RegisterTypeForNavigation<ShowPersonagem>();
            Container.RegisterType<ITsApiService, TsApiService>();
        }
    }
}
