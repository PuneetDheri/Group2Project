namespace MyMediaLibrary.Pages;

public partial class HomePage : ContentPage
{
	//establishing data 
	MediaLibrary _mediaLibrary = new MediaLibrary();

    public MediaLibrary MediaLibrary { get { return _mediaLibrary; } }

	

    string _name;

    public HomePage(string userName)
    {
        InitializeComponent();
        _name = userName;

        UserLabel.Text = $"Welcome! {_name}";

		_mediaLibrary.AddMedia("Test", TimeSpan.FromHours(1), new DateTime(2023, 8, 15), MediaGenre.Drama, MediaStatus.PlanToWatch);

    }

}