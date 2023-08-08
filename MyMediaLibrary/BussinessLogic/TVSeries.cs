using System;
namespace MyMediaLibrary
{
    // It inherits from the MediaItem base class.
    public class TVSeries : MediaItem
    {
        public string Creator { get; set; }
        public int Episodes { get; set; }
        public int Seasons { get; set; }

        // Constructor for creating a new TVSeries object.
        public TVSeries(string title, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status, string creator, int episodes, int seasons)
            : base(title, duration, releaseDate, genre, status)
        {
            Creator = creator;
            Episodes = episodes;
            Seasons = seasons;
        }
    }
}

