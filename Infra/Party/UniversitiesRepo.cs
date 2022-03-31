using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public class UniversitiesRepo : Repo<University, UniversityData>, IUniversitiesRepo
    {
        public UniversitiesRepo(TeamUPDb? db) : base(db, db?.Universities) { }
        protected override University toDomain(UniversityData d) => new(d);
    }
}
