using System;
using System.Collections.ObjectModel;

// AUTHOR : PUNEET
// interface promising read and save funtionality

namespace MyMediaLibrary.DataAccess
{
	public interface IDataAccessManager
    {
		abstract void Save(Collection<MediaItem> mediaItems) ;
        abstract Collection<MediaItem> Read();

    }
}

