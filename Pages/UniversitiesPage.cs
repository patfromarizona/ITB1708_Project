using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;
using TeamUP.Infra.Party;

namespace TeamUP.Pages
{
    public class UniversitiesPage : BasePage<UniversityView, University, IUniversitiesRepo>
    {
        public UniversitiesPage(IUniversitiesRepo r) : base(r) { }
        protected override University toObject(UniversityView? item) => new UniversityViewFactory().Create(item);
        protected override UniversityView toView(University? entity) => new UniversityViewFactory().Create(entity);
    }
}
