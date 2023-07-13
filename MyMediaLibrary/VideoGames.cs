using System;
namespace MyMediaLibrary
{
    // It inherits from the MediaItem base class.
    public class VideoGame : MediaItem
    {
        
        public string Creator { get; set; }
        public string Publisher { get; set; }

        // Constructor for creating a new VideoGame object
        public VideoGame(string title, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status, string creator, string publisher)
            : base(title, duration, releaseDate, genre, status)
        {
            Creator = creator;
            Publisher = publisher;
        }
    }
}

