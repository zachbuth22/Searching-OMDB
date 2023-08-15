using System;
using System.Net;
using Newtonsoft.Json;

namespace Searching_OMDB.Models
{
    public class MovieModelDAL
    {
        public static MovieModel GetMovie(string movie)
        {
            //Setup

            string url = $"http://www.omdbapi.com/?apikey=1e79e772&t={movie}";


            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert it to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Convert to c#
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }
    }
}
