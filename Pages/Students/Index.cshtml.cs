using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Uni_Management.Data;
using Uni_Management.Models;

namespace Uni_Management.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Uni_Management.Data.Uni_ManagementContext _context;

        public IndexModel(Uni_Management.Data.Uni_ManagementContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; } = new List<Student>();

        public async Task OnGetAsync()
        {
            Students = await _context.Student
                .Include(s => s.Course)
                .Include(s => s.Department)
                .Include(s => s.Faculty)
                .Include(s => s.University)
                .ToListAsync();
        }
    }
}
