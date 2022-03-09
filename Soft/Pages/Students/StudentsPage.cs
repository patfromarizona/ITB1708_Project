using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;
using TeamUP.Infra.Party;
using TeamUP.Infra;

namespace Soft.Pages.Students {
    public class StudentsPage : PageModel {

        //ToDo: protect from overposting attacks, enable the specific properties you want to bind to.
        //ToDo: see https://aka.ms/RazorPagesCRUD.
      
        [BindProperty] public StudentView Item { get; set; }
        public IList<StudentView> Items { get; set; }
        private readonly IStudentsRepo repo;
        public StudentsPage(TeamUPDb c) => repo = new StudentsRepo(c, c.Students);
        public string ItemId => Item?.Id ?? string.Empty;
        public IActionResult OnGetCreate() => Page();   
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new StudentViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Item = await getStudent(id);
            return Item == null ? NotFound() : Page();
        }
        private async Task<StudentView> getStudent(string id) 
            => new StudentViewFactory().Create(await repo.GetAsync(id));
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Item = await getStudent(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Item = await getStudent(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new StudentViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Items = new List<StudentView>();
            foreach (var obj in list)
            {
                var v = new StudentViewFactory().Create(obj);
                Items.Add(v);
            }
            return Page();  
        }       
    }
}
