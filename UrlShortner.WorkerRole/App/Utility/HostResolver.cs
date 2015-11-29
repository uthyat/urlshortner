using Microsoft.WindowsAzure.ServiceRuntime;
using System.Net;

namespace UrlShortner.WorkerRole.App.Utility
{
    class HostResolver
    {
        public static RoleInstanceEndpoint EndPoint
        {
            get
            {
                return RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["EndPoint1"];
            }
        }

        public static string GetShortUrl(string urlHash)
        {
            string hostName = RoleEnvironment.GetConfigurationSettingValue("HostName");

            if (string.IsNullOrWhiteSpace(hostName))
            {
                hostName = GetBaseUri();
            }

            // string.Format alternative.
            return $"{hostName}/r/{urlHash}";
        }

        public static string GetBaseUri()
        {
            RoleInstanceEndpoint endPoint = HostResolver.EndPoint;

            // string.Format alternative.
            return $"{endPoint.Protocol}://{endPoint.IPEndpoint}";
        }
    }
}
