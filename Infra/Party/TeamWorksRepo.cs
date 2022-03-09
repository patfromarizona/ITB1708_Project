using Microsoft.EntityFrameworkCore;

using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public class TeamWorksRepo : Repo<TeamWork, TeamWorkData>, ITeamWorksRepo
    {
        public TeamWorksRepo(DbContext c, DbSet<TeamWorkData> s) : base(c, s) { }
        protected override TeamWork toDomain(TeamWorkData d) => new TeamWork(d);
    }
}
