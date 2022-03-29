using TeamUP.Data.Party;

namespace TeamUP.Infra.Initializers
{
    public sealed class TeamWorksInitializer : BaseInitializer<TeamWorkData>
    {
        public TeamWorksInitializer(TeamUPDb? db) : base(db, db?.TeamWorks) { }

        internal TeamWorkData CreateTeamWork(string name, string description, bool done, int teamSize, DateTime deadline)
        {
            var teamWork = new TeamWorkData
            {
                Id = name + "work",
                Name = name,
                Description = description,
                Deadline = deadline,
                TeamSize = teamSize,
                Done = done
            };
            return teamWork;
        }
        protected override IEnumerable<TeamWorkData> getEntities => new[]
        {
            CreateTeamWork("Hard", "Hard team work", true, 5, new DateTime(2022, 12, 3)),
            CreateTeamWork("Easy", "Easy team work", false, 2, new DateTime(2022, 9, 11)),
            CreateTeamWork("Medium", "Medium team work", false, 10, new DateTime(2023, 11, 7)),
        };
    }

}
