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
        
    }
}
