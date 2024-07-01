using ParkEasyNBP.Domain.ModelsMongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Infrastructure.MongoDB
{
    public interface IZoneService  : IMongoRepository<MongoZone>
    {

    }
}
