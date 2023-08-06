namespace MyMediaLibrary.Pages;

public partial class HomePage : ContentPage
{

	string _name;

	public HomePage(string userName)
	{
		InitializeComponent();
		_name = userName;

		UserLabel.Text = $"Welcome! {_name}";

	}
}
