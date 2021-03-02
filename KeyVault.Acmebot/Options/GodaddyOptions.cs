using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVault.Acmebot.Options
{
    public static class GodaddyConstants
    {

        public const string OTEEndpoint = "https://api.ote-godaddy.com/v1";
        public const string ProductionEndpoint = "https://api.godaddy.com/v1";

        public const string DNS_TXT_RECORD = "TXT";
    }

    public class GodaddyOptions
    {
        /// <summary>
        /// as per https://developer.godaddy.com/getstarted
        /// </summary>
        public enum GodaddyEndpointSelector { OTE, LIVE }


        public GodaddyOptions()
        {
            // default endpoint selector to test-dev
            EndpointSelector = GodaddyEndpointSelector.OTE;
        }

        /// <summary>
        /// control the endpoint in use by changing this
        /// </summary>
        public GodaddyEndpointSelector EndpointSelector { get; set; }

        public string Key { get; set; }

        public string Secret { get; set; }

        private string OTEApiEndpoint
        {
            get
            {
                return GodaddyConstants.OTEEndpoint;
            }
        }

        private string ProductionApiEndpoint
        {
            get
            {
                return GodaddyConstants.ProductionEndpoint;
            }
        }

        /// <summary>
        /// depends on flipping the endpoing switch option
        /// </summary>
        internal string LiveEndPoint
        {
            get
            {
                if(EndpointSelector == GodaddyEndpointSelector.OTE)
                {
                    return GodaddyConstants.OTEEndpoint;
                }
                else
                {
                    return GodaddyConstants.ProductionEndpoint;
                }
            }
        }
    }
}
