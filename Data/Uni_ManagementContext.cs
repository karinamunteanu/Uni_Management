using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uni_Management.Models;

namespace Uni_Management.Data
{
    public class Uni_ManagementContext : DbContext
    {
        public Uni_ManagementContext (DbContextOptions<Uni_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Uni_Management.Models.Student> Student { get; set; } = default!;
        public DbSet<Uni_Management.Models.Course> Course { get; set; } = default!;
        public DbSet<Uni_Management.Models.Department> Department { get; set; } = default!;
        public DbSet<Uni_Management.Models.Faculty> Faculty { get; set; } = default!;
        public DbSet<Uni_Management.Models.University> University { get; set; } = default!;
    }
}
