﻿using System;
using System.Collections.ObjectModel;

namespace MyMediaLibrary
{
	public class MediaLibrary
	{
        private ObservableCollection<MediaItem> mediaItems; //stores list of Media Items

        public ObservableCollection<MediaItem> MediaItems { get { return mediaItems; } }




        public MediaLibrary() //constructer called when  new instace of MediaLibrary is created
		{
			mediaItems = new ObservableCollection<MediaItem>(); 
		}

        public void AddMedia(MediaItem mediaItem)
        {
            mediaItems.Add(mediaItem);
        }
        public void AddMedia(string title, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status)
        {

            //create a new MediaItem object using the parameters
            MediaItem mediaItem = new MediaItem(title, duration, releaseDate, genre, status);


            //add the mediaItem to the mediaItems list
            mediaItems.Add(mediaItem);
        }


        public bool RemoveMediaByTitle(string title)
        {
            var mediaToRemove = MediaItems.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (mediaToRemove != null)
            {
                MediaItems.Remove(mediaToRemove);
                return true;
            }
            return false;

        }


        public bool EditMedia(string title, string newTitle, MediaStatus newStatus ) {

            foreach (MediaItem mediaItem in mediaItems) {

                if (mediaItem.GetTitle().ToLower() == title.ToLower())
                {

                    // mediaItem potentially needs to set the title to the new one

                    mediaItem.SetTitle(newTitle);
                    mediaItem.SetStatus(newStatus);

                    return true;
                   
                

                }

            }
            return false;


        }
        // Search for media items in the library by genre
        public List<MediaItem> SearchByGenre(MediaGenre genre)
        {
            List<MediaItem> results = new List<MediaItem>();
            foreach (MediaItem item in mediaItems)
            {
                // Check if the media item's genre matches the specified genre
                if (item.GetGenre() == genre)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        

        //search a title (made)
        public List<MediaItem> SearchByTitle(string searchTerm) {

            List<MediaItem> results = new List<MediaItem>();

            //analyzes the list and if it is seen then it adds and returns results
            foreach (MediaItem mediaItem in mediaItems) {

                if (mediaItem.GetTitle().ToLower().Contains(searchTerm.ToLower()))
                {
                    results.Add(mediaItem);
                }

            }

            return results;
        }


        // Create playlist method
        public List<MediaItem> CreatePlaylist(List<MediaItem> selectedItems)
        {
            List<MediaItem> playlist = new List<MediaItem>();

            // Add selected media items to the playlist
            foreach (MediaItem item in selectedItems)
            {
                playlist.Add(item);
            }

            return playlist;
        }

        // delete playlist method
        public void DeletePlaylist(List<MediaItem> playlist)
        {
            //delte playlist items from the library
            foreach (MediaItem playlistItem in playlist)
            {
                mediaItems.Remove(playlistItem);
            }
        }

    }
}

