using System;
namespace MyMediaLibrary
{
    public class TVSeries : MediaItem
    {
        public string Creator { get; set; }
        public int Episodes { get; set; }
        public int Seasons { get; set; }

        public TVSeries(string title, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status, string creator, int episodes, int seasons)
            : base(title, duration, releaseDate, genre, status)
        {
            Creator = creator;
            Episodes = episodes;
            Seasons = seasons;
        }
    }
}

