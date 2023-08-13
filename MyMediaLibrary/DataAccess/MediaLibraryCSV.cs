using System;
using System.Collections.ObjectModel;

// AUTHOR : PUNEET
// used for saving in csv format,
// did not implement, ended up using Json

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

