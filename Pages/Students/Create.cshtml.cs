using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uni_Management.Data;
using Uni_Management.Models;

namespace Uni_Management.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly Uni_Management.Data.Uni_ManagementContext _context;

        public CreateModel(Uni_Management.Data.Uni_ManagementContext context)
        {
            _context = context;
        }
        public SelectList CourseList { get; set; }
        public SelectList DepartmentList { get; set; }
        public SelectList FacultyList { get; set; }
        public SelectList UniversityList { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public string SelectedCourseName { get; set; }

        [BindProperty]
        public string SelectedDepartmentName { get; set; }

        [BindProperty]
        public string SelectedFacultyName { get; set; }

        [BindProperty]
        public string SelectedUniversityName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CourseList = new SelectList(await _context.Course.ToListAsync(), "Name", "Name");
            DepartmentList = new SelectList(await _context.Department.ToListAsync(), "Name", "Name");
            FacultyList = new SelectList(await _context.Faculty.ToListAsync(), "Name", "Name");
            UniversityList = new SelectList(await _context.University.ToListAsync(), "Name", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate SelectList if model state is not valid
                CourseList = new SelectList(await _context.Course.ToListAsync(), "Name", "Name");
                DepartmentList = new SelectList(await _context.Department.ToListAsync(), "Name", "Name");
                FacultyList = new SelectList(await _context.Faculty.ToListAsync(), "Name", "Name");
                UniversityList = new SelectList(await _context.University.ToListAsync(), "Name", "Name");
                return Page();
            }

            // Set the selected IDs based on the selected names
            Student.CourseId = await _context.Course
                .Where(c => c.Name == SelectedCourseName)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            Student.DepartmentId = await _context.Department
                .Where(d => d.Name == SelectedDepartmentName)
                .Select(d => d.Id)
                .FirstOrDefaultAsync();

            Student.FacultyId = await _context.Faculty
                .Where(f => f.Name == SelectedFacultyName)
                .Select(f => f.Id)
                .FirstOrDefaultAsync();

            Student.UniversityId = await _context.University
                .Where(u => u.Name == SelectedUniversityName)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return Redirect("/Students/Index");
            
        }
    }
}