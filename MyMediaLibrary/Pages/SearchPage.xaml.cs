namespace MyMediaLibrary.Pages;

public partial class SearchPage : ContentPage
{

    private MediaLibrary _mediaLibrary;

    public SearchPage(MediaLibrary mediaLibrary)
	{
		_mediaLibrary = mediaLibrary;

		InitializeComponent();
	}

    private async void OnHomePage(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }

    void OnSearchButton(System.Object sender, System.EventArgs e)
    {
        string title = SearchBarEntry.Text;

        try
        {
            _mediaLibrary.SearchByTitle(title);

            

            
            

        }
        catch (Exception ex)
        {
            DisplayAlert("INFO", "invalid try again", "okay");
            
        }



    }

}
