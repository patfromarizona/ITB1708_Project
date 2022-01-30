#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;

namespace Soft.Pages.TeamWorks
{
    public class DeleteModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public DeleteModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamWork TeamWork { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamWork = await _context.GroupTask.FirstOrDefaultAsync(m => m.Id == id);

            if (TeamWork == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamWork = await _context.GroupTask.FindAsync(id);

            if (TeamWork != null)
            {
                _context.GroupTask.Remove(TeamWork);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
