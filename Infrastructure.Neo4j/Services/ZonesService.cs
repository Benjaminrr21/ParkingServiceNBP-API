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
        public async Task<Zone> Create(Zone z)
        {
            var query = client.Cypher
                .Create("(z:Zone $newZone)")
                .WithParam("newZone", z);
            await query.ExecuteWithoutResultsAsync();
            return z;
        }
        public async Task<bool> Delete(int zoneId)
        {
            var query = client.Cypher
                .Match("(z:Zone)")
                .Where((Zone z) => z.Id == zoneId)
                .DetachDelete("z");

            await query.ExecuteWithoutResultsAsync();
            return true;

        }
        public async Task ZoneContainsParkingPlace(int zoneId, int ppId)
        {
            var query = client.Cypher
                .Match("(z:Zone)", "(p:ParkingPlace)")
                .Where((Zone z) => z.Id == zoneId)
                .AndWhere((ParkingPlace p) => p.Id == ppId)
                .Create("(z)-[:CONTAINS]->(p)");

            await query.ExecuteWithoutResultsAsync();
        }
    }
}
