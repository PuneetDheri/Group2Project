using System;
using Microsoft.Maui.Controls;
using System.Diagnostics;


namespace MyMediaLibrary.Pages
{
    public partial class DropPage : ContentPage
    {
        private MediaLibrary _mediaLibrary;
        private MediaItem _selectedMediaItem;

        public DropPage(MediaLibrary mediaLibrary)
        {
            InitializeComponent();
            _mediaLibrary = mediaLibrary;
        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            string title = TitleEntry.Text;
            var searchResults = _mediaLibrary.SearchByTitle(title).Take(3).ToList();
            SearchResultsListView.ItemsSource = searchResults;
        }

        private void OnMediaItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedMediaItem = e.SelectedItem as MediaItem;
        }

        private async void OnDropButtonClicked(object sender, EventArgs e)
        {
            if (_selectedMediaItem != null)
            {
                _mediaLibrary.RemoveMediaByTitle(_selectedMediaItem.Title);

                await DisplayAlert("Success", $"Removed {_selectedMediaItem.Title} from library.", "OK");
                _selectedMediaItem = null;
                SearchResultsListView.ItemsSource = null;
            }
            else
            {
                await DisplayAlert("Error", "No media item selected.", "OK");
            }
        }

        private async void OnHomePage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}
