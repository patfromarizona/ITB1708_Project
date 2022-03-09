using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;
using TeamUP.Infra.Party;
using TeamUP.Infra;

namespace Soft.Pages.TeamWorks
{
    public class TeamWorksPage : PageModel{
        [BindProperty] public TeamWorkView Item { get; set; }
        public IList<TeamWorkView> Items { get; set; }
        private readonly ITeamWorksRepo repo;
        public TeamWorksPage(TeamUPDb c) => repo = new TeamWorksRepo(c, c.TeamWorks);
        public string ItemId => Item?.Id ?? string.Empty;
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new TeamWorkViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id){
            Item = await getTeamWork(id);
            return Item == null ? NotFound() : Page();
        }
        private async Task<TeamWorkView> getTeamWork(string id) 
            => new TeamWorkViewFactory().Create(await repo.GetAsync(id));
        public async Task<IActionResult> OnPostDeleteAsync(string id){
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id){
            Item = await getTeamWork(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Item = await getTeamWork(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new TeamWorkViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Items = new List<TeamWorkView>();
            foreach (var obj in list)
            {
                var v = new TeamWorkViewFactory().Create(obj);
                Items.Add(v);
            }
            return Page();
        } 
    }
}
