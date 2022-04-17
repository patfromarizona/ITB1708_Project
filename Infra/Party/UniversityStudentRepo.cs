using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public class UniversityStudentRepo : Repo<UniversityStudent, UniversityStudentData>, IUniversityStudentRepo
    {
        public UniversityStudentRepo(TeamUPDb? db) : base(db, db?.UniversityStudent) { }
        protected override UniversityStudent toDomain(UniversityStudentData d) => new(d);

        internal override IQueryable<UniversityStudentData> addFilter(IQueryable<UniversityStudentData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => contains(x.Id, y)
            || contains(x.UniversityId, y)
            || contains(x.StudentId, y));
        }
    }
}
