using Neo4jClient;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.Neo4j.Services
{
    public class ZonesService
    {
        private readonly IGraphClient client;

        public ZonesService(IGraphClient client) {
            this.client = client;
        }

        public async Task<IEnumerable<Zone>> GetAll()
        {
            var query = client.Cypher
                .Match("(z: Zone)")
                .Return(z => z.As<Zone>());

            return (await query.ResultsAsync).ToList();
        }
        public async Task Create(Zone z)
        {
            var query = client.Cypher
                .Create("(z:Zone $newZone)")
                .WithParam("newZone", z);
            await query.ExecuteWithoutResultsAsync();
        }
    }
}
