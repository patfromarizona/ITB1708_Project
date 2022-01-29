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
    public class IndexModel : PageModel
    {
        private readonly Soft.Data.ApplicationDbContext _context;

        public IndexModel(Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GroupTask> GroupTask { get;set; }

        public async Task OnGetAsync()
        {
            GroupTask = await _context.GroupTask.ToListAsync();
        }
    }
}
