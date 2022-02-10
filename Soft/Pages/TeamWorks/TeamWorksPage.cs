using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace Soft.Pages.TeamWorks
{
    public class TeamWorksPage : PageModel{
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        [BindProperty] public TeamWorkView TeamWork { get; set; }
        public IList<TeamWorkView> TeamWorks { get; set; }
        private readonly ApplicationDbContext context;
        public TeamWorksPage(ApplicationDbContext c) => context = c;
        public IActionResult OnGetCreate()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new TeamWorkViewFactory().Create(TeamWork).Data;

            context.TeamWorks.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id){
            TeamWork = await getTeamWork(id);
            return TeamWork == null ? NotFound() : Page();
        }
        private async Task<TeamWorkView> getTeamWork(string id){
            if (id == null) return null;
            var d = await context.TeamWorks.FirstOrDefaultAsync(m => m.TeamWorkId == id);            
            if (d == null) return null;
            return new TeamWorkViewFactory().Create(new TeamWork(d));
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id){
            if (id == null){
                return NotFound();
            }
            var d = await context.TeamWorks.FindAsync(id);
            if (d != null){
                context.TeamWorks.Remove(d);
                await context.SaveChangesAsync();
            }
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new TeamWorkViewFactory().Create(TeamWork).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teamWorkExists(TeamWork.TeamWorkId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", "Index");
        }

        

        public async Task OnGetIndexAsync()
        {
            var list = await context.TeamWorks.ToListAsync();
            TeamWorks = new List<TeamWorkView>();
            foreach (var d in list)
            {
                var v = new TeamWorkViewFactory().Create(new TeamWork(d));
                TeamWorks.Add(v);
            }
        }

        private bool teamWorkExists(string id)
            => context.TeamWorks.Any(e => e.TeamWorkId == id);
    }
}
