using System;
namespace MyMediaLibrary
{
    // enums for the status of media item in library database
    public enum MediaStatus
    {
        Watching,
        Completed,
        OnHold,
        PlanToWatch,
        Dropped
    }

    // enums for the genre of a media item in library database
    public enum MediaGenre
    {
        Action,
        Adventure,
        Comedy,
        Drama,
        Fantasy,
        Horror,
        Mystery,
        Romance,
        SciFi,
        Thriller
    }


    public class MediaItem
	{
        //used protected to allow subclasses to modify the properties
        protected string Title { get; set; }
        protected TimeSpan Duration { get; set; }
        protected DateTime ReleaseDate { get; set; }
        protected MediaGenre Genre { get; set; }
        protected MediaStatus Status { get; set; }

        public string GetTitle()
        {
            return Title;
        }

        
        public void SetTitle(string newTitle) {

            Title = newTitle;

        }

        public MediaStatus GetStatus() {

            return Status;

        }

        public void SetStatus(MediaStatus newStatus) {
            Status = newStatus;
        }


        // constructor 
        public MediaItem(string title, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status)
        {
            Title = title;
            Duration = duration;
            ReleaseDate = releaseDate;
            Genre = genre;
            Status = status;
        }
    }
}

