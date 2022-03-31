using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party
{
    public sealed class UniversityView : BaseView
    {
        [DisplayName("University Name")] public string UniversityName { get; set; } = string.Empty;
        [DisplayName("Location")] public string? UniversityLocation { get; set; }
        [DisplayName("Amount of students")] public int? StudentsAmount { get; set; }
        [DisplayName("Cost of education")] public int? CostOfStudying { get; set; }
        [DisplayName("Currency")] public string? Currency { get; set; }
    }

    public sealed class UniversityViewFactory : BaseViewFactory<UniversityView, University, UniversityData>
    {
        protected override University toEntity(UniversityData d) => new(d);
    }
}
