using Xamarin.Forms;

[assembly: Dependency(typeof(AtInternet.iOS.XitiService))]
namespace AtInternet.iOS
{
    public class XitiService : IXitiService
    {
        public XitiService()
        {
        }

        public bool Init()
        {
            int siteId = 1;
            string server = "xiti.com";
            string log = "logc236";
            string secureLog = "logs1236";

            var t = new Binding.ATInternetProxy();
            return t.InitTrackerWithSiteId(siteId, server, log, secureLog, true, false);
        }

        public bool Track()
        {

            var t = new Binding.ATInternetProxy();
            var result = t.TrackViewWithView("HelloWorldIOS");
            return result;
        }

        public string Errors()
        {

            var t = new Binding.ATInternetProxy();
            var result = t.Errors;
            return result;
        }
    }
}
