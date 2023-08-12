using System;
using System.Collections.ObjectModel;
using Xamarin.KotlinX.Coroutines.Channels;

namespace MyMediaLibrary.DataAccess
{
	public class MediaLibraryCSV
	{

        string _fileName;
        private MediaLibrary _mediaLibrary;

        public MediaLibraryCSV(string fileName)
        {
            _fileName = fileName;
        }


        public void WriteProducts(ObservableCollection<MediaItem> MediaItems)
        {
            
          
        }



    }
}

