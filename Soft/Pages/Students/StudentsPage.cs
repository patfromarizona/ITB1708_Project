using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace Soft.Pages.Students {
    public class StudentsPage : PageModel {

        //ToDo: protect from overposting attacks, enable the specific properties you want to bind to.
        //ToDo: see https://aka.ms/RazorPagesCRUD.
      
        private readonly ApplicationDbContext context;
        [BindProperty] public StudentView Student { get; set; }
        public IList<StudentView> Students { get; set; }
        public StudentsPage(ApplicationDbContext c) => context = c;

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
            var d = new StudentViewFactory().Create(Student).Data;

            context.Students.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Student = await getStudent(id);
            return Student == null ? NotFound() : Page();
        }

        private async Task<StudentView> getStudent(string id)
        {

            if (id == null) return null;
            var d = await context.Students.FirstOrDefaultAsync(m => m.StudentId == id);
            if (d == null) return null;
            return Student = new StudentViewFactory().Create(new Student(d));

        }

        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Student = await getStudent(id);
            return Student == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Students.FindAsync(id);

            if (d != null)
            {
                context.Students.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Student = await getStudent(id);
            return Student == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new StudentViewFactory().Create(Student).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentExists(Student.StudentId))
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
            var list = await context.Students.ToListAsync();
            Students = new List<StudentView>();
            foreach (var d in list)
            {
                var v = new StudentViewFactory().Create(new Student(d));
                Students.Add(v);
            }
        }
        private bool studentExists(string id) => context.Students.Any(e => e.StudentId == id);

    }
}
