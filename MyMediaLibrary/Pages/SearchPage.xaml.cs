namespace MyMediaLibrary.Pages;

public partial class SearchPage : ContentPage
{

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
        string title = SearchBarEntry.Text;
        var searchResults = _mediaLibrary.SearchByTitle(title);



        SearchResultsListView.ItemsSource = searchResults;

       

    }

    //added
}
