using CollectionViewMemoryLeak.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NodaLibrary.NodaHelpers.Diagnostic;
using NodaMobileSales.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewMemoryLeak.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {

        [ObservableProperty]
        private String _cviCount;

        [ObservableProperty]
        private String _lviCount;

        public MainPageViewModel(NavigationService navigationService) : base(navigationService)
        {
            Title = "MainPage";
            Counter.Increment(this.GetType().Name);
        }

        ~MainPageViewModel()
        {
            Counter.Decrement(this.GetType().Name);
        }


        [RelayCommand]
        public async Task GoToCollection()
        {
            await _navigationService.GoToAsync<CollectionViewViewModel>();
        }

        [RelayCommand]
        public async Task GoToList()
        {
            await _navigationService.GoToAsync<ListViewViewModel>();
        }

        internal void ReloadCount()
        {
            if (Counter.dictionnary != null)
            {
                CviCount = "P : " + Counter.dictionnary.FirstOrDefault(x => x.Key == nameof(CollectionViewPage)).Value + " VM : " + Counter.dictionnary.FirstOrDefault(x => x.Key == nameof(CollectionViewViewModel)).Value;
                LviCount = "P : " + Counter.dictionnary.FirstOrDefault(x => x.Key == nameof(ListViewPage)).Value + " VM : " + Counter.dictionnary.FirstOrDefault(x => x.Key == nameof(ListViewPage)).Value;

            }
        }
    }
}
