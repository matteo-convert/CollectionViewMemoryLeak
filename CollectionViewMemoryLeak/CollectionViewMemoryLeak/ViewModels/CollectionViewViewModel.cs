using CollectionViewMemoryLeak.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using NodaLibrary.NodaHelpers.Diagnostic;
using NodaMobileSales.Maui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewMemoryLeak.ViewModels
{
    public partial class CollectionViewViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<CDE_ENT> _list;
        public CollectionViewViewModel(NavigationService navigationService) : base(navigationService)
        {
            Title = "CollectionView Page";
            Counter.Increment(this.GetType().Name);
            LoadListCde();
        }

        ~CollectionViewViewModel()
        {
            Counter.Decrement(this.GetType().Name);
        }
        private void LoadListCde()
        {
            var list = JsonConvert.DeserializeObject<List<CDE_ENT>>(File.ReadAllText(@"C:\Users\matco\Downloads\cde_ent.json"));

            List = new ObservableCollection<CDE_ENT>(list);

        }


        [RelayCommand]
        public async Task Back()
        {
            await _navigationService.BackAsync();
        }

    }
}
