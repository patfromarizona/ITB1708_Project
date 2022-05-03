using Microsoft.AspNetCore.Mvc.Rendering;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;


namespace TeamUP.Pages.Party
{
    public class StudentsPage : PagedPage<StudentView, Student, IStudentsRepo>
    {

        //ToDo: protect from overposting attacks, enable the specific properties you want to bind to.
        //ToDo: see https://aka.ms/RazorPagesCRUD.
        public StudentsPage(IStudentsRepo r) : base(r) { }
        protected override Student toObject(StudentView? item) => new StudentViewFactory().Create(item);
        protected override StudentView toView(Student? entity) => new StudentViewFactory().Create(entity);

        public override string[] IndexColumns { get; } = {
           nameof(Student.FirstName),
           nameof(Student.LastName),
           nameof(Student.Age),
           nameof(Student.Gender),
           nameof(Student.YearInUniversity),
        };

        public static IEnumerable<SelectListItem> Genders
            => Enum.GetValues<IsoGender>()?.Select(x => new SelectListItem(x.Description(), x.ToString())) ?? new List<SelectListItem>();

        public static string GenderDescription(IsoGender? g)
            => (g ?? IsoGender.NotApplicable).Description();

        public override object? GetValue(string name, StudentView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(StudentView.Gender) ? GenderDescription((IsoGender) r) : r;
        }
    }
}
