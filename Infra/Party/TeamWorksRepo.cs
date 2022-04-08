using Microsoft.EntityFrameworkCore;

using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public class TeamWorksRepo : Repo<TeamWork, TeamWorkData>, ITeamWorksRepo
    {
        public TeamWorksRepo(TeamUPDb? db) : base(db, db?.TeamWorks) { }
        protected override TeamWork toDomain(TeamWorkData d) => new(d);
        internal override IQueryable<TeamWorkData> addFilter(IQueryable<TeamWorkData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => contains(x.Id, y)
            || contains(x.Deadline.ToString(), y)
            || contains(x.Description, y)
            || contains(x.TeamSize.ToString(), y)
            || contains(x.Done.ToString(), y));
        }
    }
}
