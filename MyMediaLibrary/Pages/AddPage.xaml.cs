using System.Diagnostics;

namespace MyMediaLibrary.Pages;

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



    void OnAddMediaClicked(System.Object sender, System.EventArgs e)
    {
        string title = TitleEntry.Text;

        int minutes = int.Parse(DurationPicker.Text);
        int hours = minutes / 60;

        TimeSpan duration = new TimeSpan(hours, minutes % 60, 0);
        MediaGenre genre = (MediaGenre)Enum.Parse(typeof(MediaGenre), GenrePicker.SelectedItem.ToString());
        MediaStatus status = (MediaStatus)Enum.Parse(typeof(MediaStatus), StatusPicker.SelectedItem.ToString());


        MediaItem mediaItem = new MediaItem(title, duration, DateTime.Now, genre, status);

        _mediaLibrary.AddMedia(mediaItem);


        Navigation.PopAsync(); // go back (HomePage)
    }

}
