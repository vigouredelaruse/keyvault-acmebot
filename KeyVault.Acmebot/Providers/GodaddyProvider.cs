using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GodaddyWrapper;
using GodaddyWrapper.Requests;

using KeyVault.Acmebot.client.godaddy;
using KeyVault.Acmebot.Options;

namespace KeyVault.Acmebot.Providers
{
    public class GodaddyProvider : IDnsProvider
    {
        private GoDaddyClient _godaddyClient;

        public GodaddyProvider(GodaddyOptions options)
        {
            _godaddyClient = new GoDaddyClient(options);
        }
        public int PropagationSeconds => 10;

        public async Task CreateTxtRecordAsync(DnsZone zone, string relativeRecordName, IEnumerable<string> values)
        {
            await _godaddyClient.CreateTxtRecordAsync(zone, relativeRecordName, values);
        }

        public async Task DeleteTxtRecordAsync(DnsZone zone, string relativeRecordName)
        {

            await _godaddyClient.DeleteTxtRecordAsync(zone, relativeRecordName);

        }

        public async Task<IReadOnlyList<DnsZone>> ListZonesAsync()
        {

            //var result = await _godaddyClient.RetrieveDomainList(new DomainRetrieve());

            //// technically this not a zone result but a domain domain
            //return result.Select(x => new DnsZone { Id = x.DomainId.ToString(), Name = x.Domain }).ToArray();
            return await _godaddyClient.ListZonesAsync();
        }
    }
}
