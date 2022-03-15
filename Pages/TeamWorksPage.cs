using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace TeamUP.Pages
{
    public class TeamWorksPage : BasePage<TeamWorkView, TeamWork, ITeamWorksRepo>
    {
        public TeamWorksPage(ITeamWorksRepo r) : base(r) { }
        protected override TeamWork toObject(TeamWorkView? item) => new TeamWorkViewFactory().Create(item);
        protected override TeamWorkView toView(TeamWork? entity) => new TeamWorkViewFactory().Create(entity);
    }
}
