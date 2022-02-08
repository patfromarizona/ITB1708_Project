
using System.ComponentModel.DataAnnotations;

namespace TeamUP.Data.Party
{
    public class StudentData
    {
        [Key] public string StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Gender { get; set; }
        public int? Age { get; set; }
        public int? YearInUniversity { get; set; }
    }
}
