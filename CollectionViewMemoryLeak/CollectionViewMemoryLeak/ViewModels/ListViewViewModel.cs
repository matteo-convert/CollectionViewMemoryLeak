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
    public partial class ListViewViewModel : ViewModelBase
    {


        public ListViewViewModel(NavigationService navigationService) : base(navigationService)
        {
            Title = "ListView Page";
            Counter.Increment(this.GetType().Name);
        }

        ~ListViewViewModel()
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
