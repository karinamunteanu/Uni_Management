using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Uni_Management.Data;
using Uni_Management.Models;

namespace Uni_Management.Pages.Faculties
{
    public class DeleteModel : PageModel
    {
        private readonly Uni_Management.Data.Uni_ManagementContext _context;

        public DeleteModel(Uni_Management.Data.Uni_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Faculty Faculty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty.FirstOrDefaultAsync(m => m.Id == id);

            if (faculty == null)
            {
                return NotFound();
            }
            else
            {
                Faculty = faculty;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty.FindAsync(id);
            if (faculty != null)
            {
                Faculty = faculty;
                _context.Faculty.Remove(Faculty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
