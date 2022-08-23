using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class scoped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "MentorId", "Department", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Sodiq Agboola", 0 },
                    { 2, 4, "Emmanuel Victor", 0 },
                    { 3, 3, "Meenat Victoria", 0 },
                    { 4, 5, "Ayodeji Smart", 0 },
                    { 5, 0, "Michael Smith", 0 },
                    { 6, 2, "Elon Musk", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "MentorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "MentorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "MentorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "MentorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "MentorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "MentorId",
                keyValue: 6);
        }
    }
}
