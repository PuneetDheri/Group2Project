namespace MyMediaLibrary.Pages;

public partial class AddPage : ContentPage
{
    private MediaLibrary _mediaLibrary;

    public AddPage(MediaLibrary mediaLibrary)
	{
		InitializeComponent();


        _mediaLibrary = mediaLibrary;
    }

    

    void OnAddMediaClicked(System.Object sender, System.EventArgs e)
    {
        string title = TitleEntry.Text;
        TimeSpan duration = DurationPicker.Time;
        MediaGenre genre = (MediaGenre)Enum.Parse(typeof(MediaGenre), GenrePicker.SelectedItem.ToString());
        MediaStatus status = (MediaStatus)Enum.Parse(typeof(MediaStatus), StatusPicker.SelectedItem.ToString());

        _mediaLibrary.AddMedia(title, duration, DateTime.Now, genre, status);

        Navigation.PopAsync(); // go back (HomePage)
    }

}
