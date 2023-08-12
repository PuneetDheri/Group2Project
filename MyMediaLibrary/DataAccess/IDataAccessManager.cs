using System;
using System.Collections.ObjectModel;

namespace MyMediaLibrary.DataAccess
{
	public interface IDataAccessManager
    {
		abstract void Save(Collection<MediaItem> mediaItems) ;
        abstract Collection<MediaItem> Read();

    }
}

