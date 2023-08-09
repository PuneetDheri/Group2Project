using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MyMediaLibrary.Pages;

public partial class HomePage : ContentPage
{


    //establishing data 
    public MediaLibrary _mediaLibrary = new MediaLibrary();

    public MediaLibrary UsersMediaLibrary { get { return _mediaLibrary; } set { _mediaLibrary = value; } }


    string _name;

    public HomePage(string userName)
    {
        InitializeComponent();
        _name = userName;

        UserLabel.Text = $"Welcome! {_name}";

        _mediaLibrary.AddMedia("Test1", TimeSpan.FromHours(1), DateTime.Now, MediaGenre.Action, MediaStatus.PlanToWatch);
        _mediaLibrary.AddMedia("Test2", TimeSpan.FromHours(1), DateTime.Now, MediaGenre.Drama, MediaStatus.PlanToWatch);
        _mediaLibrary.AddMedia("Test3", TimeSpan.FromHours(1), DateTime.Now, MediaGenre.SciFi, MediaStatus.Dropped);
        _mediaLibrary.AddMedia("Test4", TimeSpan.FromHours(1), DateTime.Now, MediaGenre.Comedy, MediaStatus.PlanToWatch);

        UsersMediaLibraryListView.ItemsSource = _mediaLibrary.MediaItems;
        BindingContext = this;

    }



    async void OnAddMediaButtonClicked(System.Object sender, System.EventArgs e)
    {
        AddPage addPage = new AddPage(UsersMediaLibrary);
        await Navigation.PushAsync(addPage, true);

    }

    async void OnEditButtonClicked(object sender, EventArgs e)
    {
        EditPage editPage = new EditPage(_mediaLibrary); 
        await Navigation.PushAsync(editPage);
    }


    private async void OnDropButtonClicked(object sender, EventArgs e)
    {
        DropPage dropPage = new DropPage();
        await Navigation.PushAsync(dropPage);
    }

    private async void SearchButtonClicked(System.Object sender, System.EventArgs e)
    {
        SearchPage searchPage = new SearchPage(_mediaLibrary);
        await Navigation.PushAsync(searchPage);
    }
}