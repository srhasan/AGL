using System.Net;

namespace Agl.Services
{
    public class WebClientService : IWebClientService
    {
        private readonly string _url;
        public WebClientService(string url)
        {
            _url = url;
        }
        public string GetPetOwnerJson()
        {
            string jsonResult;
            using (WebClient wc = new WebClient())
            {
                jsonResult = wc.DownloadString(_url);
            }
            return jsonResult;
        }
    }
}
