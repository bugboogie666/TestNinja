using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;

        private IWebClientManager _webClient;

        public InstallerHelper(IWebClientManager webclient)
        {
            _webClient = webclient;

        } 

        public bool DownloadInstaller(string customerName, string installerName)
        {
            //client = _webClient;
            
            try
            {
                _webClient.Download(
                    string.Format("http://example.com/{0}/{1}",
                    customerName, installerName),
                     _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}