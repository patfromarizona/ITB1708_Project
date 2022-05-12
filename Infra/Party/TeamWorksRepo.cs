using Microsoft.EntityFrameworkCore;

using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public sealed class TeamWorksRepo : Repo<TeamWork, TeamWorkData>, ITeamWorksRepo
    {
        public TeamWorksRepo(TeamUPDb? db) : base(db, db?.TeamWorks) { }
        protected internal override TeamWork toDomain(TeamWorkData d) => new(d);
        internal override IQueryable<TeamWorkData> addFilter(IQueryable<TeamWorkData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => x.Id.Contains(y)
            || x.Deadline.ToString().Contains(y)
            || x.Description.Contains(y)
            || x.Name.Contains(y)
            || x.TeamSize.ToString().Contains(y)
            || x.Done.ToString().Contains(y));
        }
    }
}
