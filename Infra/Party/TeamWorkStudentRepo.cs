using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public class TeamWorkStudentRepo : Repo<TeamWorkStudent, TeamWorkStudentData>, ITeamWorkStudentRepo
    {
        public TeamWorkStudentRepo(TeamUPDb? db) : base(db, db?.TeamWorkStudent) { }
        protected override TeamWorkStudent toDomain(TeamWorkStudentData d) => new(d);

        internal override IQueryable<TeamWorkStudentData> addFilter(IQueryable<TeamWorkStudentData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => contains(x.Id, y)
            || contains(x.TeamWorkId, y)
            || contains(x.StudentId, y));
        }
    }
}
