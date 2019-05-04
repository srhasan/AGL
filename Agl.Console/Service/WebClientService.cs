using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Console.Service
{
    public class WebClientService: IWebClientService
    {
        private readonly string _url;
        public WebClientService()
        {
            _url = ConfigurationManager.AppSettings["jsonUrl"];
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
