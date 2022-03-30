using Microsoft.EntityFrameworkCore;
using TeamUP.Data;
using TeamUP.Data.Party;

namespace TeamUP.Infra.Initializers
{
    public sealed class StudentsInitializer : BaseInitializer<StudentData>
    {
        public StudentsInitializer(TeamUPDb? db) : base(db, db?.Students) { }

        private StudentData createStudent(string firstName, string lastName, bool gender, int age, int yearInUniversity)
        {
            var student = new StudentData
            {
                Id = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Age = age,
                YearInUniversity = yearInUniversity
            };
            return student;
        }

        protected override IEnumerable<StudentData> getEntities => new[]
{

            createStudent("Greg", "Homie", false, 19, 1),
            createStudent("Tom", "Brown", false, 21, 2),
            createStudent("Mark", "Frankfurt", false, 22, 3),
        };
    }

    public sealed class TeamWorksInitializer : BaseInitializer<TeamWorkData>
    {
        public TeamWorksInitializer(TeamUPDb? db) : base(db, db?.TeamWorks) { }

        private TeamWorkData createTeamWork(string name, string description, bool done, int teamSize, DateTime deadline)
        {
            var teamWork = new TeamWorkData
            {
                Id = name + "work",
                Name = name,
                Done = done,
                Description = description,
                TeamSize = teamSize,
                Deadline = deadline
            };
            return teamWork;
        }

        protected override IEnumerable<TeamWorkData> getEntities => new[]
        {

            createTeamWork("Easy", "It's easy work", false, 3, new DateTime(2022, 4, 23)),
            createTeamWork("Medium", "It's medium work", false, 5, new DateTime(2022, 3, 31)),
            createTeamWork("Hard", "It's hard work", false, 10, new DateTime(2022, 5, 9)),
        };
    }

    public abstract class BaseInitializer<TData> where TData : EntityData
    {
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;



        protected BaseInitializer(DbContext? c, DbSet<TData>? s)
        {
            db = c;
            set = s;
        }
        public void Init()
        {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            db?.SaveChanges();
        }
        protected abstract IEnumerable<TData> getEntities { get; }
          
    } 
}
