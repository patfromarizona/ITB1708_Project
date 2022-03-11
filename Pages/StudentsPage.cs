using TeamUP.Domain.Party;
using TeamUP.Facade.Party;
using TeamUP.Infra.Party;
using TeamUP.Infra;

namespace TeamUP.Pages
{
    public class StudentsPage : BasePage<StudentView, Student, IStudentsRepo>
    {

        //ToDo: protect from overposting attacks, enable the specific properties you want to bind to.
        //ToDo: see https://aka.ms/RazorPagesCRUD.     
        public StudentsPage(IStudentsRepo r) : base(r) { }
        protected override Student toObject(StudentView item) => new StudentViewFactory().Create(item);
        protected override StudentView toView(Student entity) => new StudentViewFactory().Create(entity);
    }
}
