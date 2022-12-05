using CollectionViewMemoryLeak.ViewModels;

namespace CollectionViewMemoryLeak;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}
}
