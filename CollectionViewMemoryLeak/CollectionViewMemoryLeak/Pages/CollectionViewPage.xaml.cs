using CollectionViewMemoryLeak.ViewModels;
using NodaLibrary.NodaHelpers.Diagnostic;

namespace CollectionViewMemoryLeak.Pages;

public partial class CollectionViewPage : ContentPage
{
	public CollectionViewPage(CollectionViewViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext= viewModel;

		Counter.Increment(this.GetType().Name);
	}

	~CollectionViewPage()
	{
        Counter.Decrement(this.GetType().Name);
    }
}