using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public class StudentsRepo : Repo<Student, StudentData>, IStudentsRepo
    {
        public StudentsRepo(TeamUPDb? db) : base(db, db?.Students) { }

        protected override Student toDomain(StudentData d) => new(d);

        internal override IQueryable<StudentData> addFilter(IQueryable<StudentData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => contains(x.Id, y)
            || contains(x.FirstName, y) 
            || contains(x.LastName, y)
            || contains(x.Age.ToString(), y)
            || contains(x.YearInUniversity.ToString(), y));
        }


    }
}
