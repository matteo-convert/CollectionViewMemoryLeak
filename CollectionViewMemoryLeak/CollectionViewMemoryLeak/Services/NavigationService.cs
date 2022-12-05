using CommunityToolkit.Maui.Views;
using NodaLibrary.NodaHelpers.Diagnostic;

namespace NodaMobileSales.Maui.Services
{

    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        //Methode d'affichage des pages
        public async Task GoToAsync<T>(string viewName = null) where T : class
        {
            var view = GetPage<T>(viewName);

            await GoToPage<T>(view);
        }



        public async Task BackAsync()
        {
            
            await PageNavigation.PopAsync();

            Counter.Log();
        }


        private async Task GoToPage<T>(Page view) where T : class
        {
            await PageNavigation.PushAsync(view);
        }

        private Page GetPage<T>(string viewName) where T : class
        {
            var viewType = GetPageType(typeof(T), viewName);
            var view = _serviceProvider.GetService(viewType) as Page;

            if (view == null) 
                throw new NullReferenceException($"View {viewType}");

            return view;
        }

        private Type GetPageType(Type viewModelType, string viewName = null)
        {
            viewName = viewName ?? viewModelType.FullName

                                                    .Replace("CollectionViewMemoryLeak.ViewModels", "CollectionViewMemoryLeak.Pages")
                                                    .Replace("ViewModel", "Page");
            var viewType = Type.GetType(viewName);

            return viewType;
        }

        private INavigation PageNavigation
        {
            get => Application.Current.MainPage.Navigation;
        }

    }
}
