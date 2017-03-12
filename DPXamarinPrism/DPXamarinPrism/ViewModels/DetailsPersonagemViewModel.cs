
using System;
using Prism.Mvvm;
using Prism.Navigation;

using DPXamarin.Core.Services;
using DPXamarin.Core.Models;

namespace DPXamarinPrism.ViewModels
{
    public class DetailsPersonagemViewModel : BindableBase, INavigationAware
    {
        private readonly ITsApiService _tsApiService;
        private Comic _selectedComic;

        public Comic SelectedComic
        {
            get { return _selectedComic; }
            set { SetProperty(ref _selectedComic, value); }
        }

        public DetailsPersonagemViewModel(ITsApiService tsApiService)
        {
            _tsApiService = tsApiService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            int id = Convert.ToInt32(parameters["comic"]);
            SelectedComic = await _tsApiService.GetComicById(id);
        }
    }
}
