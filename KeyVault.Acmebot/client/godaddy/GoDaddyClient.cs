using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using GodaddyWrapper.Requests;

using KeyVault.Acmebot.client.godaddy.model;
using KeyVault.Acmebot.Options;
using KeyVault.Acmebot.Providers;

namespace KeyVault.Acmebot.client.godaddy
{


    public class GoDaddyClient : IGodaddyClient
    {

        private static System.Net.Http.HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// as per https://josef.codes/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/
        /// and https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        /// </summary>
        /// <param name="httpClient"></param>
        public GoDaddyClient(GodaddyOptions options)
        {
            _httpClient.BaseAddress = new Uri(options.LiveEndPoint);
            _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(options.Key, options.Secret);
        }

        public async Task CreateTxtRecordAsync(DnsZone zone, string relativeRecordName, IEnumerable<string> values)
        {
            var urlTemplate = "/domains/{zone}/records/{type}/{name}";
            var url = String.Format(urlTemplate, zone.Name, GodaddyConstants.DNS_TXT_RECORD, relativeRecordName);
            var txtRecord = new GoDaddyDnsRecord()
            {
                name = relativeRecordName,
                data = string.Join(" ", values)
            };

            await _httpClient.PutAsJsonAsync<GoDaddyDnsRecord>(url, txtRecord);
        }

        public Task DeleteTxtRecordAsync(DnsZone zone, string relativeRecordName) => throw new NotImplementedException();
        public Task<IReadOnlyList<DnsZone>> ListZonesAsync() => throw new NotImplementedException();
    }
}
