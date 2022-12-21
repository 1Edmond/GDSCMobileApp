namespace GDSCMobileApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	IDatabaseManager<Proprietaire> ProprietaireManager; 
	public MainPage(IDatabaseManager<Proprietaire> manager)
	{
		InitializeComponent();
		ProprietaireManager = manager;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		ProprietaireManager.AddElement(new Proprietaire()
		{
			Id = Guid.NewGuid(),
			Nom = "Wilfried"
		});
		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

