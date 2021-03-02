using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVault.Acmebot.client.godaddy.model
{
    /// <summary>
    /// as per
    /// curl -X GET "https://api.ote-godaddy.com/v1/domains" -H  "accept: application/json" -H  "Authorization: sso-key blahblahblah"
    /// </summary>
    public class GodaddyDomainRecord
    {
        public DateTime createdAt { get; set; }
        public DateTime deletedAt { get; set; }
        public string domain { get; set; }
        public int domainId { get; set; }
        public bool expirationProtected { get; set; }
        public DateTime expires { get; set; }
        public bool exposeWhois { get; set; }
        public bool holdRegistrar { get; set; }
        public bool locked { get; set; }
        public object nameServers { get; set; }
        public bool privacy { get; set; }
        public bool renewAuto { get; set; }
        public bool renewable { get; set; }
        public string status { get; set; }
        public bool transferProtected { get; set; }

    }
}
