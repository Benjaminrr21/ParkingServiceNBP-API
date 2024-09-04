using Neo4jClient;
using ParkEasyNBP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.Neo4j.Services
{
    public class ParkingsPlacesServices
    {
        private readonly IGraphClient client;

        public ParkingsPlacesServices(IGraphClient client)
        {
            this.client = client;
        }
        public async Task<IEnumerable<ParkingPlace>> GetAll()
        {
            var query = client.Cypher
                .Match("(z: ParkingPlace)")
                .Return(z => z.As<ParkingPlace>());

            return (await query.ResultsAsync).ToList();
        }
        public async Task<ParkingPlace> Create(ParkingPlace z)
        {
            var query = client.Cypher
                .Create("(z:ParkingPlace $newParkingPlace)")
                .WithParam("newParkingPlace", z);
            await query.ExecuteWithoutResultsAsync();
            return z;
        }
    }
}
