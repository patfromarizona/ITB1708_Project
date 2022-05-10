using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party
{
    public sealed class UniversityStudentView : BaseView
    {
        [Required] [DisplayName("Student")]  public string StudentId { get; set; } = string.Empty;
        [Required] [DisplayName("University")]  public string UniversityId { get; set; } = string.Empty;
    }

    public sealed class UniversityStudentViewFactory : BaseViewFactory<UniversityStudentView, UniversityStudent, UniversityStudentData>
    {
        protected override UniversityStudent toEntity(UniversityStudentData d) => new(d);
    }
}
