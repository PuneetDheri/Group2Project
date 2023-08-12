using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace MyMediaLibrary.DataAccess
{
	public class JsonAccessManager : IDataAccessManager
    {
        private readonly string _filePath = $"{FileSystem.Current.AppDataDirectory}/mediaList.json";
        public JsonAccessManager()
		{

		}
        
        public Collection<MediaItem> Read()
        {

            using (FileStream stream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                if (stream.Length == 0)
                {
                    return new Collection<MediaItem>();
                }

               return JsonSerializer.Deserialize<Collection<MediaItem>>(stream);
            }
        }

        public void Save(Collection<MediaItem> mediaItems)
        {
            using (FileStream stream = new FileStream(_filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(stream, mediaItems); 
            }

        }
    }
}

