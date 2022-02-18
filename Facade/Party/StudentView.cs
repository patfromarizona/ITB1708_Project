
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace TeamUP.Facade.Party
{
    public class StudentView
    {
        [DisplayName("Studend Id")] [Required] public string StudentId { get; set; }
        [DisplayName("First Name")] [Required] public string FirstName { get; set; }
        [DisplayName("Last Name")] [Required] public string LastName { get; set; }
        [DisplayName("Gender")] public bool? Gender { get; set; }
        [DisplayName("Age")] [Range(18,99)] public int? Age { get; set; }
        [DisplayName("Year in University")] public int? YearInUniversity { get; set; }
        [DisplayName("Full Name")] public string? FullName { get; set; }
    }
}
