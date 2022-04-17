using Microsoft.AspNetCore.Mvc.Rendering;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;


namespace TeamUP.Pages.Party
{
    public class TeamWorkStudentPage : PagedPage<TeamWorkStudentView, TeamWorkStudent, ITeamWorkStudentRepo>
    {
        private readonly ITeamWorksRepo teamWorks;
        private readonly IStudentsRepo students;
        public TeamWorkStudentPage(ITeamWorkStudentRepo r, IStudentsRepo s, ITeamWorksRepo t) : base(r)
        {
            teamWorks = t;
            students = s;
        }
        protected override TeamWorkStudent toObject(TeamWorkStudentView? item) => new TeamWorkStudentViewFactory().Create(item);
        protected override TeamWorkStudentView toView(TeamWorkStudent? entity) => new TeamWorkStudentViewFactory().Create(entity);

        public override string[] IndexColumns { get; } = {
           nameof(TeamWorkStudentView.TeamWorkId),
           nameof(TeamWorkStudentView.StudentId)
        };

        public IEnumerable<SelectListItem> TeamWorks
            => teamWorks?.GetAll(x => x.ToString())?.Select(x => new SelectListItem(x.ToString(), x.Id)) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Students
           => students?.GetAll(x => x.ToString())?.Select(x => new SelectListItem(x.ToString(), x.Id)) ?? new List<SelectListItem>();

        public string TeamWorkName(string? teamWorkId = null)
            => TeamWorks?.FirstOrDefault(x => x.Value == (teamWorkId ?? string.Empty))?.Text ?? "Unspecified";
        public string StudentName(string? studentId = null)
            => Students?.FirstOrDefault(x => x.Value == (studentId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, TeamWorkStudentView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(TeamWorkStudentView.StudentId) ? StudentName(r as string)
                : name == nameof(TeamWorkStudentView.TeamWorkId) ? TeamWorkName(r as string)
                : r;
        }
    }
}
