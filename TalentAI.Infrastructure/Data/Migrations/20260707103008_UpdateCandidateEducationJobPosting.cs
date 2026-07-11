using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateEducationJobPosting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryAllowance",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "University",
                table: "Candidates");

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryFrom",
                table: "JobPostings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalaryTo",
                table: "JobPostings",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GPA",
                table: "Educations",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "Educations",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Candidates",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryFrom",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "SalaryTo",
                table: "JobPostings");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "University",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "SalaryAllowance",
                table: "JobPostings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Educations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "GPA",
                table: "Candidates",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Candidates",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "Candidates",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
