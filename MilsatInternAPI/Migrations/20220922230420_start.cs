using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MentorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "MentorId", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("055004a1-92f9-46a0-9646-8bb1398e8d7b"), "", 6, "admin@milsat.com", "Admin", 0, null, new byte[] { 80, 31, 87, 214, 34, 91, 154, 0, 123, 48, 253, 184, 156, 28, 131, 29, 88, 3, 142, 145, 126, 196, 119, 44, 242, 231, 35, 208, 49, 167, 33, 87, 198, 110, 162, 145, 59, 74, 187, 248, 241, 152, 46, 37, 151, 131, 133, 184, 149, 76, 75, 179, 159, 119, 162, 73, 25, 114, 99, 134, 73, 196, 235, 16 }, new byte[] { 100, 107, 137, 33, 34, 223, 126, 231, 77, 248, 3, 171, 157, 200, 100, 100, 12, 46, 92, 177, 48, 221, 255, 143, 61, 78, 157, 59, 40, 42, 107, 233, 9, 55, 21, 90, 102, 26, 74, 251, 43, 163, 115, 229, 67, 226, 63, 207, 43, 175, 55, 236, 149, 215, 246, 80, 34, 224, 14, 211, 18, 193, 197, 30, 60, 85, 133, 42, 192, 254, 173, 16, 186, 42, 241, 97, 254, 45, 140, 179, 165, 215, 91, 217, 207, 38, 16, 191, 103, 87, 149, 147, 149, 142, 120, 39, 23, 89, 48, 135, 159, 140, 69, 216, 192, 248, 233, 237, 215, 53, 250, 47, 51, 80, 153, 22, 194, 217, 57, 68, 41, 168, 55, 207, 17, 22, 193, 65 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "MentorId", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("1cc2a7ba-b24d-4b87-962f-16d677767037"), "", 1, "mentor2@gmail.com", "Sodiq Agboola", 0, null, new byte[] { 255, 36, 82, 98, 59, 210, 18, 200, 1, 34, 186, 178, 115, 197, 113, 215, 203, 246, 39, 200, 31, 181, 110, 61, 140, 123, 124, 94, 169, 172, 252, 184, 99, 222, 144, 105, 85, 210, 215, 115, 96, 67, 54, 254, 205, 191, 253, 174, 26, 114, 1, 211, 22, 7, 158, 157, 192, 82, 16, 223, 82, 187, 45, 134 }, new byte[] { 207, 40, 94, 89, 153, 80, 123, 177, 199, 122, 141, 113, 97, 19, 187, 222, 234, 128, 171, 184, 210, 119, 21, 16, 9, 143, 223, 170, 114, 204, 143, 26, 126, 10, 252, 64, 29, 187, 112, 14, 2, 248, 183, 3, 60, 124, 80, 47, 31, 2, 126, 234, 22, 224, 103, 52, 25, 23, 96, 24, 85, 176, 102, 237, 107, 202, 89, 43, 92, 100, 68, 215, 18, 230, 64, 125, 224, 203, 179, 182, 213, 58, 138, 184, 133, 26, 18, 233, 250, 199, 48, 81, 219, 126, 29, 174, 211, 80, 22, 45, 36, 130, 33, 49, 12, 235, 250, 202, 200, 90, 12, 44, 135, 155, 204, 150, 90, 85, 161, 55, 180, 36, 54, 181, 123, 124, 23, 71 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "MentorId", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("ba7720c3-d86f-4865-a55b-80aa8a7a0553"), "", 1, "mentor1@gmail.com", "Sodiq Agboola", 0, null, new byte[] { 97, 230, 204, 114, 160, 255, 240, 107, 61, 136, 77, 232, 6, 98, 62, 182, 125, 93, 240, 9, 63, 75, 58, 35, 47, 181, 37, 223, 69, 177, 132, 142, 57, 148, 84, 83, 0, 183, 124, 70, 103, 127, 33, 80, 116, 48, 64, 81, 152, 73, 81, 176, 32, 179, 112, 139, 167, 92, 129, 59, 213, 153, 111, 87 }, new byte[] { 181, 10, 216, 57, 59, 199, 14, 113, 19, 59, 4, 72, 249, 36, 220, 78, 233, 4, 142, 107, 192, 135, 231, 222, 73, 129, 178, 244, 153, 173, 248, 212, 76, 50, 30, 85, 225, 195, 207, 161, 160, 154, 142, 173, 168, 93, 116, 146, 15, 239, 14, 89, 156, 36, 19, 96, 129, 32, 166, 62, 74, 110, 53, 53, 12, 143, 177, 255, 9, 124, 153, 45, 51, 32, 206, 214, 229, 52, 164, 59, 15, 200, 134, 186, 243, 20, 128, 223, 1, 152, 21, 128, 152, 181, 115, 85, 133, 143, 55, 124, 18, 191, 175, 232, 204, 42, 19, 159, 118, 87, 78, 105, 181, 65, 211, 9, 177, 252, 240, 230, 21, 128, 55, 203, 43, 162, 193, 62 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "Id", "CreatedOn", "Status", "UserId" },
                values: new object[] { 1, new DateTime(2022, 9, 22, 23, 4, 20, 639, DateTimeKind.Utc).AddTicks(5894), 0, new Guid("ba7720c3-d86f-4865-a55b-80aa8a7a0553") });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "Id", "CreatedOn", "Status", "UserId" },
                values: new object[] { 2, new DateTime(2022, 9, 22, 23, 4, 20, 639, DateTimeKind.Utc).AddTicks(5896), 0, new Guid("1cc2a7ba-b24d-4b87-962f-16d677767037") });

            migrationBuilder.CreateIndex(
                name: "IX_Intern_MentorId",
                table: "Intern",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_UserId",
                table: "Intern",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_UserId",
                table: "Mentor",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MentorId",
                table: "Users",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Users_MentorId",
                table: "Intern",
                column: "MentorId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Users_UserId",
                table: "Intern",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentor_Users_UserId",
                table: "Mentor",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentor_Users_UserId",
                table: "Mentor");

            migrationBuilder.DropTable(
                name: "Intern");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Mentor");
        }
    }
}
