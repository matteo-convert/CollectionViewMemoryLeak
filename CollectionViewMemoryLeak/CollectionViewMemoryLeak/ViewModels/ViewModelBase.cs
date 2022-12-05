using CommunityToolkit.Mvvm.ComponentModel;
using NodaMobileSales.Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewMemoryLeak.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        protected readonly NavigationService _navigationService;

        [ObservableProperty]
        private String _title;

        public ViewModelBase(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }


    }
}
