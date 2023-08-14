using System.Diagnostics;

namespace MyMediaLibrary.Pages;

// AUTHOR : PUNEET
// adds new entries to media library by calling AddMedia method
// button to go back to homepage


public partial class AddPage : ContentPage
{
    private MediaLibrary _mediaLibrary;

    public AddPage(MediaLibrary mediaLibrary)
    {
        InitializeComponent();

        StatusPicker.ItemsSource = Enum.GetValues(typeof(MediaStatus));
        GenrePicker.ItemsSource = Enum.GetValues(typeof(MediaGenre));
       
        _mediaLibrary = mediaLibrary;
    }



     async void OnAddMediaClicked(System.Object sender, System.EventArgs e)
    {
        string title = TitleEntry.Text;
        string category = CategoryEntry.Text;
        DateTime releaseDate = ReleaseDatePicker.Date;
        int minutes = int.Parse(DurationPicker.Text);
        int hours = minutes / 60;

        TimeSpan duration = new TimeSpan(hours, minutes % 60, 0);
        MediaGenre genre = (MediaGenre)Enum.Parse(typeof(MediaGenre), GenrePicker.SelectedItem.ToString());
        MediaStatus status = (MediaStatus)Enum.Parse(typeof(MediaStatus), StatusPicker.SelectedItem.ToString());


        MediaItem mediaItem = new MediaItem(title,category, duration, releaseDate, genre, status);

        _mediaLibrary.AddMedia(mediaItem);
        await DisplayAlert("Success", $"Added {mediaItem.Title} to library.", "OK");

        TitleEntry.Text = "";
        CategoryEntry.Text="";
        DurationPicker.Text = "";
        ReleaseDatePicker.Date = DateTime.Now;
        GenrePicker.SelectedItem = "";
        StatusPicker.SelectedItem = "";
    }

    private async void OnHomePage(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // go back (HomePage)
    }
}
