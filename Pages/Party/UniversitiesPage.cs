using TeamUP.Domain.Party;
using TeamUP.Facade.Party;


namespace TeamUP.Pages.Party
{
    public class UniversitiesPage : PagedPage<UniversityView, University, IUniversitiesRepo>
    {
        public UniversitiesPage(IUniversitiesRepo r) : base(r) { }
        protected override University toObject(UniversityView? item) => new UniversityViewFactory().Create(item);
        protected override UniversityView toView(University? entity) => new UniversityViewFactory().Create(entity);
    }
}
