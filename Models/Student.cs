namespace Uni_Management.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Foreign keys
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public int UniversityId { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public Department Department { get; set; }
        public Faculty Faculty { get; set; }
        public University University { get; set; }
    }
}
