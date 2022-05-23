using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party {
    public sealed class TeamWorkStudentView : BaseView {
        [Required] [DisplayName("Student")] public string StudentId { get; set; } = string.Empty;
        [Required] [DisplayName("TeamWork")] public string TeamWorkId { get; set; } = string.Empty;
    }

    public sealed class TeamWorkStudentViewFactory : BaseViewFactory<TeamWorkStudentView, TeamWorkStudent, TeamWorkStudentData> {
        protected override TeamWorkStudent toEntity(TeamWorkStudentData d) => new(d);
    }
}
