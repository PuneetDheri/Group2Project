using System;
namespace MyMediaLibrary
{
	public class MediaLibrary
	{
		private List<MediaItem> mediaItems; //stores list of Media Items
		public MediaLibrary() //constructer called when  new instace of MediaLibrary is created
		{
			mediaItems = new List<MediaItem>();
		}

        public void AddMedia(string title, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status)
        {

            //create a new MediaItem object using the parameters
            MediaItem mediaItem = new MediaItem(title, duration, releaseDate, genre, status);


            //add the mediaItem to the mediaItems list
            mediaItems.Add(mediaItem);
        }
    }
}

