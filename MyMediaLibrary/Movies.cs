using System;
namespace MyMediaLibrary
{
    // It inherits from the MediaItem base class.
    public class Movie : MediaItem
    {
        public string Director { get; set; }
        public double Rating { get; set; }


        // Constructor for the a new Movies Object
        public Movie(string title, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status, string director, double rating)
            : base(title, duration, releaseDate, genre, status)
        {
            Director = director;
            Rating = rating;
        }
    }
}

