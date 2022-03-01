using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;
using TeamUP.Infra.Party;

namespace Soft.Pages.TeamWorks
{
    public class TeamWorksPage : PageModel{
        [BindProperty] public TeamWorkView TeamWork { get; set; }
        public IList<TeamWorkView> TeamWorks { get; set; }
        private readonly ITeamWorksRepo repo;
        public TeamWorksPage(ApplicationDbContext c) => repo = new TeamWorksRepo(c, c.TeamWorks);
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new TeamWorkViewFactory().Create(TeamWork));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id){
            TeamWork = await getTeamWork(id);
            return TeamWork == null ? NotFound() : Page();
        }
        private async Task<TeamWorkView> getTeamWork(string id) 
            => new TeamWorkViewFactory().Create(await repo.GetAsync(id));
        public async Task<IActionResult> OnPostDeleteAsync(string id){
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id){
            TeamWork = await getTeamWork(id);
            return TeamWork == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            TeamWork = await getTeamWork(id);
            return TeamWork == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new TeamWorkViewFactory().Create(TeamWork);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            TeamWorks = new List<TeamWorkView>();
            foreach (var obj in list)
            {
                var v = new TeamWorkViewFactory().Create(obj);
                TeamWorks.Add(v);
            }
            return Page();
        } 
    }
}
