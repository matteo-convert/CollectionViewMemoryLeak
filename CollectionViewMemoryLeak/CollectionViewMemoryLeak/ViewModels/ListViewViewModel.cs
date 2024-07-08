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
    public partial class ListViewViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<CDE_ENT> _list;

        public ListViewViewModel(NavigationService navigationService) : base(navigationService)
        {
            Title = "ListView Page";
            Counter.Increment(this.GetType().Name);
            LoadListCde();
        }

        private void LoadListCde()
        {
            var list = JsonConvert.DeserializeObject<List<CDE_ENT>>(File.ReadAllText(@"C:\Users\matco\Downloads\cde_ent.json"));

            List = new ObservableCollection<CDE_ENT>(list);

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
