using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Uni_Management.Data;
using Uni_Management.Models;

namespace Uni_Management.Pages.Universities
{
    public class DetailsModel : PageModel
    {
        private readonly Uni_Management.Data.Uni_ManagementContext _context;

        public DetailsModel(Uni_Management.Data.Uni_ManagementContext context)
        {
            _context = context;
        }

        public University University { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.University.FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }
            else
            {
                University = university;
            }
            return Page();
        }
    }
}
