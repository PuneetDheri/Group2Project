namespace MyMediaLibrary.Pages;

public partial class SearchPage : ContentPage
{
    //AUTHOR: JULIUS
    //to use the method of SearchByTitle to iterate through the list
    //and find the title that is associated with the user input
    //returns it


    //added an instance of medialibrary
    private MediaLibrary _mediaLibrary;

    
    public SearchPage(MediaLibrary mediaLibrary)
	{
		_mediaLibrary = mediaLibrary;


        BindingContext = this;

		InitializeComponent();
	}

    private async void OnHomePage(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }

    void OnSearchButton(System.Object sender, System.EventArgs e)
    {

        try
        {
            string title = SearchBarEntry.Text;
            var searchResults = _mediaLibrary.SearchByTitle(title);



            SearchResultsListView.ItemsSource = searchResults;
        }
        catch (Exception ex)
        {
            DisplayAlert("INFO", ex.Message, "Okay");
        }
       

    }

    //added
}
