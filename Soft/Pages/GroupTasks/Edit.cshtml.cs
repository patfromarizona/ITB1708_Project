#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soft.Data;

namespace Soft.Pages.GroupTasks
{
    public class EditModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public EditModel(Soft.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GroupTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupTaskExists(GroupTask.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GroupTaskExists(string id)
        {
            return _context.GroupTask.Any(e => e.Id == id);
        }
    }
}
