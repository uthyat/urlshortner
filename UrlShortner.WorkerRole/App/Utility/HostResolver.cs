using Microsoft.WindowsAzure.ServiceRuntime;

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
            RoleInstanceEndpoint endPoint = HostResolver.EndPoint;

            // string.Format alternative.
            return $"{endPoint.Protocol}://{endPoint.IPEndpoint.Address}/{urlHash}";
        }

        public static string GetBaseUri()
        {
            RoleInstanceEndpoint endPoint = HostResolver.EndPoint;

            // string.Format alternative.
            return $"{endPoint.Protocol}://{endPoint.IPEndpoint}";
        }
    }
}
