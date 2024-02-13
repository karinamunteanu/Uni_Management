using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyPropertiesToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                    name: "CourseId",
                    table: "Student",
                    nullable: false,
                    defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Student",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
