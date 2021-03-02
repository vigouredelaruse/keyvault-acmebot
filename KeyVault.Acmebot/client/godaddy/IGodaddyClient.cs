using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using KeyVault.Acmebot.Providers;

namespace KeyVault.Acmebot.client.godaddy
{
    public interface IGodaddyClient 
    {
        Task<IReadOnlyList<DnsZone>> ListZonesAsync();
        Task CreateTxtRecordAsync(DnsZone zone, string relativeRecordName, IEnumerable<string> values);
        Task DeleteTxtRecordAsync(DnsZone zone, string relativeRecordName);
    }
}
