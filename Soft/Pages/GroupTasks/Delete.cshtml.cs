#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;

namespace Soft.Pages.GroupTasks
{
    public class DeleteModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public DeleteModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GroupTask GroupTask { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroupTask = await _context.GroupTask.FirstOrDefaultAsync(m => m.Id == id);

            if (GroupTask == null)
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

            GroupTask = await _context.GroupTask.FindAsync(id);

            if (GroupTask != null)
            {
                _context.GroupTask.Remove(GroupTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
