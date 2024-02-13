using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uni_Management.Data;
using Uni_Management.Models;

namespace Uni_Management.Pages.Universities
{
    public class CreateModel : PageModel
    {
        private readonly Uni_Management.Data.Uni_ManagementContext _context;

        public CreateModel(Uni_Management.Data.Uni_ManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public University University { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.University.Add(University);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
