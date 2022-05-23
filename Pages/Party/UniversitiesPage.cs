using Microsoft.AspNetCore.Mvc.Rendering;
using TeamUP.Aids;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;


namespace TeamUP.Pages.Party {
    public class UniversitiesPage : PagedPage<UniversityView, University, IUniversitiesRepo> {
        private readonly ILocationsRepo locations;
        public UniversitiesPage(IUniversitiesRepo r, ILocationsRepo l) : base(r) => locations = l;
        protected override University toObject(UniversityView? item) => new UniversityViewFactory().Create(item);
        protected override UniversityView toView(University? entity) => new UniversityViewFactory().Create(entity);

        public override string[] IndexColumns { get; } = {
           nameof(UniversityView.Name),
           nameof(UniversityView.Location),
           nameof(UniversityView.StudentsAmount)
        };
        public IEnumerable<SelectListItem> Countries
            => locations?.GetAll(x => x.Country)?.Select(x => new SelectListItem(x.Country, x.Id)) ?? new List<SelectListItem>();
        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, UniversityView v) {
            var r = base.GetValue(name, v);
            return name == nameof(UniversityView.Location) ? CountryName(r as string) : r;
        }
    }
}
