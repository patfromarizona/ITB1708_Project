using Microsoft.EntityFrameworkCore;
using TeamUP.Data.Party;
using TeamUP.Domain;
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
            return q.Where(x => 
            x.Id.Contains(y) ||
            x.FirstName.Contains(y) ||
            x.LastName.Contains(y) ||
            x.Age.ToString().Contains(y) ||
            x.YearInUniversity.ToString().Contains(y));
        }
    }
}
