using System;
namespace MyMediaLibrary
{
    // It inherits from the MediaItem base class.
    public class Book : MediaItem
    {
        public string Author { get; set; }
        public double Rating { get; set; }


        // Constructor for creating a new Book object.
        public Book(string title,string category, TimeSpan duration, DateTime releaseDate, MediaGenre genre, MediaStatus status, string author, double rating)
            : base(title,category, duration, releaseDate, genre, status)
        {
            Author = author;
            Rating = rating;
        }
    }
}

