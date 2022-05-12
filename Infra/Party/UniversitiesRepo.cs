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
    public sealed class UniversitiesRepo : Repo<University, UniversityData>, IUniversitiesRepo
    {
        public UniversitiesRepo(TeamUPDb? db) : base(db, db?.Universities) { }
        protected internal override University toDomain(UniversityData d) => new(d);

        internal override IQueryable<UniversityData> addFilter(IQueryable<UniversityData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => x.Id.Contains(y)
            || x.Name.Contains(y)
            || x.Location.Contains(y)
            || x.Currency.Contains(y)
            || x.CostOfStudying.ToString().Contains(y)
            || x.StudentsAmount.ToString().Contains(y));
        }
    }
}
