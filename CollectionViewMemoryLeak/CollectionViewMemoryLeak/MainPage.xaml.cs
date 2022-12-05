using CollectionViewMemoryLeak.ViewModels;

namespace CollectionViewMemoryLeak;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();


		this.BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((MainPageViewModel)BindingContext).ReloadCount();
    }

}

