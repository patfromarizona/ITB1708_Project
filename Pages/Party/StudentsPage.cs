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
    }
}
