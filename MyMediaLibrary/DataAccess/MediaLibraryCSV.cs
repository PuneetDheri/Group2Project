using System;
using System.Collections.ObjectModel;

namespace MyMediaLibrary.DataAccess
{
	public class MediaLibraryCSV : IDataAccessManager
	{

        string _fileName;
        private MediaLibrary _mediaLibrary;


        public Collection<MediaItem> Read()
        {
            return null;
        }

        public void Save(Collection<MediaItem> mediaItems)
        {
        }


    }
}

