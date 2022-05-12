using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public sealed class TeamWorkStudentRepo : Repo<TeamWorkStudent, TeamWorkStudentData>, ITeamWorkStudentRepo
    {
        public TeamWorkStudentRepo(TeamUPDb? db) : base(db, db?.TeamWorkStudent) { }
        protected internal override TeamWorkStudent toDomain(TeamWorkStudentData d) => new(d);

        internal override IQueryable<TeamWorkStudentData> addFilter(IQueryable<TeamWorkStudentData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => x.Id.Contains(y)
            || x.TeamWorkId.Contains(y)
            || x.StudentId.Contains(y));
        }
    }
}
