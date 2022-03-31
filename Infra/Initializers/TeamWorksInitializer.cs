using TeamUP.Data.Party;

namespace TeamUP.Infra.Initializers
{
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
}
