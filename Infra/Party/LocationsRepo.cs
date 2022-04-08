using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public class LocationsRepo : Repo<Location, LocationData>, ILocationsRepo
    {
        public LocationsRepo(TeamUPDb? db) : base(db, db?.Locations) { }
        protected override Location toDomain(LocationData d) => new(d);

    }
}
