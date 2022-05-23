using Microsoft.AspNetCore.Mvc.Rendering;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;


namespace TeamUP.Pages.Party {
    public class UniversityStudentPage : PagedPage<UniversityStudentView, UniversityStudent, IUniversityStudentRepo> {
        private readonly IUniversitiesRepo universities;
        private readonly IStudentsRepo students;
        public UniversityStudentPage(IUniversityStudentRepo r, IStudentsRepo s, IUniversitiesRepo u) : base(r) {
            universities = u;
            students = s;
        }
        protected override UniversityStudent toObject(UniversityStudentView? item) => new UniversityStudentViewFactory().Create(item);
        protected override UniversityStudentView toView(UniversityStudent? entity) => new UniversityStudentViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = {
           nameof(UniversityStudentView.UniversityId),
           nameof(UniversityStudentView.StudentId)
        };
        public IEnumerable<SelectListItem> Universities
            => universities?.GetAll(x => x.ToString())?.Select(x => new SelectListItem(x.ToString(), x.Id)) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Students
           => students?.GetAll(x => x.ToString())?.Select(x => new SelectListItem(x.ToString(), x.Id)) ?? new List<SelectListItem>();

        public string UniversityName(string? universityId = null)
            => Universities?.FirstOrDefault(x => x.Value == (universityId ?? string.Empty))?.Text ?? "Unspecified";
        public string StudentName(string? studentId = null)
            => Students?.FirstOrDefault(x => x.Value == (studentId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, UniversityStudentView v) {
            var r = base.GetValue(name, v);
            return name == nameof(UniversityStudentView.StudentId) ? StudentName(r as string)
                : name == nameof(UniversityStudentView.UniversityId) ? UniversityName(r as string)
                : r;
        }
    }
}
