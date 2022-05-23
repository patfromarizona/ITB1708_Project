using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party {
    public sealed class UniversityStudentRepo : Repo<UniversityStudent, UniversityStudentData>, IUniversityStudentRepo {
        public UniversityStudentRepo(TeamUPDb? db) : base(db, db?.UniversityStudent) { }
        protected internal override UniversityStudent toDomain(UniversityStudentData d) => new(d);
        internal override IQueryable<UniversityStudentData> addFilter(IQueryable<UniversityStudentData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => x.Id.Contains(y)
            || x.UniversityId.Contains(y)
            || x.StudentId.Contains(y));
        }
    }
}
