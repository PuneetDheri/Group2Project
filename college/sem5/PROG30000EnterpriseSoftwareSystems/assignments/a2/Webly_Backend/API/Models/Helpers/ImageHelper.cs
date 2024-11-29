using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace API.Models.Helpers
{
    public  class ImageHelper
    {
        public  IEnumerable<string> GetTags(string imageUrl)
        {
            string apiKey = "acc_7caf3efa23734ad";
            string apiSecret = "b638acfa8a36ca62e507fbde62bb1412";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");

            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            var response = client.Execute(request);

            string[] lines = response.Content.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> results = lines.Where(l => l.Contains("\"tag\""));
            var result = new List<string>();
            foreach (var line in results)
                yield return line.Split(':')[2].Replace("}", string.Empty).Replace("\"", string.Empty).Replace("]", string.Empty);
        }
    }
}