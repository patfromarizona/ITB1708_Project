
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party
{
    public sealed class StudentView : BaseView
    {
        [DisplayName("First Name")] public string? FirstName { get; set; }
        [DisplayName("Last Name")] public string? LastName { get; set; }
        [DisplayName("Gender")] public bool? Gender { get; set; }
        [DisplayName("Age")] [Range(18,99)] public int? Age { get; set; }
        [DisplayName("Year in University")] public int? YearInUniversity { get; set; }
        [DisplayName("Full Name")] public string? FullName { get; set; }
    }

    public sealed class StudentViewFactory : BaseViewFactory<StudentView, Student, StudentData>
    {
        protected override Student toEntity(StudentData d) => new(d);
        public override StudentView Create(Student? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}
