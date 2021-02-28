using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GodaddyWrapper;
using GodaddyWrapper.Requests;

using KeyVault.Acmebot.Options;

namespace KeyVault.Acmebot.Providers
{
    public class GodaddyProvider : IDnsProvider
    {
        private Client _godaddyClient;

        public GodaddyProvider(GodaddyOptions options)
        {
            _godaddyClient = new Client(options.Key, options.Secret, options.ApiEndpoint);
        }
        public int PropagationSeconds => 10;

        public async Task CreateTxtRecordAsync(DnsZone zone, string relativeRecordName, IEnumerable<string> values)
        {
            List<DNSRecord> records = new List<DNSRecord>();

            foreach(var value in values)
            {
                records.Add(
                         new DNSRecord()
                            {
                                Ttl = 60,
                                Type = "TXT",
                                Name = relativeRecordName,
                                Data = value
                         });
            }

            await _godaddyClient.AddDNSRecordsToDomain(records, zone.Name);
        }

        public async Task DeleteTxtRecordAsync(DnsZone zone, string relativeRecordName)
        {
            var records = await _godaddyClient.RetrieveDNSRecordsWithTypeAndName(new DNSRecordRetrieve(), zone.Name, "TXT", relativeRecordName); //  .ListRecordsAsync(zone.Id);

            var recordsToDelete = records.Where(r => r.Name == relativeRecordName && r.Type == "TXT");
            foreach(var deleteThis in recordsToDelete)
            {
                records.Remove(deleteThis);
            }



        }

        public async Task<IReadOnlyList<DnsZone>> ListZonesAsync()
        {

            var result = await _godaddyClient.RetrieveDomainList(new DomainRetrieve());

            // technically this not a zone result but a domain domain
            return result.Select(x => new DnsZone { Id = x.DomainId.ToString(), Name = x.Domain }).ToArray();

        }
    }
}
