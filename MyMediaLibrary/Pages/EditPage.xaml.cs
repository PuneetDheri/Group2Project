using System.Linq;

namespace MyMediaLibrary.Pages
{
    public partial class EditPage : ContentPage
    {
        private MediaLibrary _mediaLibrary;
        private MediaItem _selectedItem;

        public EditPage(MediaLibrary mediaLibrary)
        {
            InitializeComponent();
            _mediaLibrary = mediaLibrary;
            MediaList.ItemsSource = _mediaLibrary.MediaItems;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedItem = e.SelectedItem as MediaItem;
            if (_selectedItem != null)
            {
                TitleEntry.Text = _selectedItem.Title;
                DurationEntry.Text = _selectedItem.Duration.ToString();
                ReleaseDatePicker.Date = _selectedItem.ReleaseDate;
                GenrePicker.SelectedItem = _selectedItem.Genre.ToString();
                StatusPicker.SelectedItem = _selectedItem.Status.ToString();
            }
        }

        private void OnSaveChanges(object sender, EventArgs e)
        {
            if (_selectedItem != null)
            {
                _selectedItem.Title = TitleEntry.Text;
                _selectedItem.Duration = TimeSpan.Parse(DurationEntry.Text); 
                _selectedItem.ReleaseDate = ReleaseDatePicker.Date;
                _selectedItem.Genre = (MediaGenre)Enum.Parse(typeof(MediaGenre), GenrePicker.SelectedItem.ToString());
                _selectedItem.Status = (MediaStatus)Enum.Parse(typeof(MediaStatus), StatusPicker.SelectedItem.ToString());

            }
        }
    }
}
