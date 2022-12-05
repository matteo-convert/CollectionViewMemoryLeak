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
    public partial class CollectionViewViewModel : ViewModelBase
    {

        public CollectionViewViewModel(NavigationService navigationService) : base(navigationService)
        {
            Title = "CollectionView Page";
            Counter.Increment(this.GetType().Name);
        }

        ~CollectionViewViewModel()
        {
            Counter.Decrement(this.GetType().Name);
        }


        [RelayCommand]
        public async Task Back()
        {
            await _navigationService.BackAsync();
        }

    }
}
