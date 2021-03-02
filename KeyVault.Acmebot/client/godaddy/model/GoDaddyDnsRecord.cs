using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVault.Acmebot.client.godaddy.model
{
    public class GoDaddyDnsRecord
    {
        public string name { get; set; }

        public string data { get; set; }

        public string type { get; set; }

        public string ttl { get; set; }
    }
}
