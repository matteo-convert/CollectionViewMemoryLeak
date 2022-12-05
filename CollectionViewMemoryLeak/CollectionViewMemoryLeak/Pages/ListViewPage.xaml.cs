using CollectionViewMemoryLeak.ViewModels;
using NodaLibrary.NodaHelpers.Diagnostic;

namespace CollectionViewMemoryLeak.Pages;

public partial class ListViewPage : ContentPage
{
	public ListViewPage(ListViewViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;


        Counter.Increment(this.GetType().Name);
    }

	~ListViewPage()
	{

        Counter.Decrement(this.GetType().Name);
    }
}