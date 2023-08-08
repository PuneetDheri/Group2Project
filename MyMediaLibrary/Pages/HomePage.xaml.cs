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

		_mediaLibrary.AddMedia("Test1", TimeSpan.FromHours(1),  DateTime.Now, MediaGenre.Drama, MediaStatus.PlanToWatch);
        _mediaLibrary.AddMedia("Test2", TimeSpan.FromHours(1), DateTime.Now, MediaGenre.Drama, MediaStatus.PlanToWatch);
        _mediaLibrary.AddMedia("Test3", TimeSpan.FromHours(1), DateTime.Now, MediaGenre.Drama, MediaStatus.PlanToWatch);
        _mediaLibrary.AddMedia("Test4", TimeSpan.FromHours(1), DateTime.Now, MediaGenre.Drama, MediaStatus.PlanToWatch);


        BindingContext = this;

    }

    async void OnAddMediaButtonClicked(System.Object sender, System.EventArgs e)
    {
        AddPage addPage = new AddPage(_mediaLibrary);
        await Navigation.PushAsync(addPage);
    }

    async void OnEditButtonClicked(object sender, EventArgs e)
    {
        EditPage editPage = new EditPage();
        await Navigation.PushAsync(editPage);
    }

    private async void OnDropButtonClicked(object sender, EventArgs e)
    {
        DropPage dropPage = new DropPage();
        await Navigation.PushAsync(dropPage);
    }

}