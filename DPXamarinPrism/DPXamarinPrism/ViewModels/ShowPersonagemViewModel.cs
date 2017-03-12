
using Prism.Mvvm;
using Prism.Navigation;

using DPXamarin.Core.Services;
using DPXamarin.Core.Models;
using System.Collections.ObjectModel;
using Prism.Commands;
using Xamarin.Forms;

namespace DPXamarinPrism.ViewModels
{
    public class ShowPersonagemViewModel : BindableBase, INavigationAware
    {
        private readonly ITsApiService _tsApiService;
        private readonly INavigationService _navigationService;
        private ObservableCollection<Personagem> _listComics;

        public ObservableCollection<Personagem> ListComics
        {
            get { return _listComics; }
            set { SetProperty(ref _listComics, value); }
        }

        public ShowPersonagemViewModel(ITsApiService tsApiService, INavigationService navigationService)
        {
            _tsApiService = tsApiService;
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var comics = await _tsApiService.GetComics();
            ListComics = new ObservableCollection<Personagem>(comics);
        }

        private DelegateCommand<ItemTappedEventArgs> _goToDetailPage;

        public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
        {
            get
            {
                if (_goToDetailPage == null)
                {
                    _goToDetailPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
                    {
                        NavigationParameters param = new NavigationParameters();
                        var comic = selected.Item as Personagem;
                        param.Add("comic",  comic.Id);
                        await _navigationService.NavigateAsync("DetailPersonagem", param);
                    });
                }

                return _goToDetailPage;
            }
        }
    }
}
