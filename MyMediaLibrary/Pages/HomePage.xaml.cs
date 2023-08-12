using System.Collections.ObjectModel;
using System.Diagnostics;
using MyMediaLibrary.DataAccess;

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
        var dropPage = new DropPage(_mediaLibrary);
        await Navigation.PushAsync(dropPage);
    }

    private async void SearchButtonClicked(System.Object sender, System.EventArgs e)
    {
        SearchPage searchPage = new SearchPage(_mediaLibrary);
        await Navigation.PushAsync(searchPage);
    }
}