using System.Linq;
using System.Net.Http;

namespace WEbApiWithAttrCtor.Services
{
    public interface INeedInit
    {
        //// marker interface
    }

    public interface IVerifyIpAddress : INeedInit
    {
        bool IsValidIpAddress(HttpRequestMessage request);
    }

   public class VerifyIpAddress : IVerifyIpAddress
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";

        private readonly string[] _validIps = new[] { "::1", "127.0.0.1" };

        public bool IsValidIpAddress(HttpRequestMessage request)
        {
            var address = GetIpAddress(request);

            return _validIps.Any(ip => ip == address);
        }

        private static string GetIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }
            //Self-hosting
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }
            //Owin-hosting
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic ctx = request.Properties[OwinContext];
                if (ctx != null)
                {
                    return ctx.Request.RemoteIpAddress;
                }
            }
            return null;
        }
    }
}