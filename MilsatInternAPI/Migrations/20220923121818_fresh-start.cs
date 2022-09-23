using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class freshstart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Mentor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Intern_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Intern_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("8a89f847-9d2e-482d-b3e7-bc0efffb4419"), "", 0, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 230, 35, 212, 15, 152, 159, 222, 245, 252, 227, 34, 215, 146, 10, 130, 88, 169, 100, 20, 76, 48, 210, 52, 120, 244, 230, 20, 4, 222, 8, 241, 88, 189, 240, 163, 232, 254, 62, 95, 41, 245, 2, 244, 205, 224, 40, 124, 187, 199, 21, 156, 193, 203, 204, 148, 221, 251, 37, 221, 220, 39, 252, 139, 233 }, new byte[] { 98, 215, 228, 45, 116, 146, 241, 250, 48, 155, 197, 52, 97, 83, 36, 46, 189, 74, 59, 120, 241, 96, 47, 19, 187, 250, 228, 19, 68, 130, 154, 240, 119, 193, 19, 73, 40, 71, 190, 189, 192, 78, 197, 134, 106, 120, 26, 79, 78, 243, 172, 231, 54, 67, 225, 216, 152, 112, 251, 73, 93, 82, 229, 97, 140, 234, 242, 56, 95, 16, 193, 133, 120, 91, 246, 208, 110, 249, 59, 136, 107, 212, 145, 109, 108, 88, 183, 139, 156, 170, 43, 5, 221, 145, 65, 216, 86, 128, 56, 245, 92, 50, 251, 209, 230, 2, 56, 218, 122, 30, 199, 9, 101, 156, 247, 60, 44, 216, 219, 159, 33, 144, 111, 148, 239, 202, 111, 214 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("f7446f14-f6f2-4df6-bc26-5618ff050b98"), "", 0, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 166, 179, 103, 193, 122, 161, 70, 109, 103, 108, 152, 248, 172, 246, 99, 38, 80, 194, 187, 121, 42, 161, 182, 225, 25, 118, 201, 109, 213, 40, 115, 25, 134, 148, 8, 219, 222, 225, 169, 92, 14, 126, 87, 0, 60, 49, 221, 38, 131, 10, 249, 190, 196, 219, 136, 171, 148, 50, 87, 30, 128, 240, 141, 11 }, new byte[] { 20, 95, 129, 210, 80, 216, 65, 45, 146, 16, 238, 106, 125, 98, 169, 153, 40, 130, 129, 213, 121, 39, 120, 81, 100, 8, 190, 97, 95, 21, 255, 246, 21, 133, 219, 84, 38, 189, 128, 120, 76, 155, 131, 5, 224, 247, 232, 64, 4, 38, 205, 124, 45, 75, 141, 21, 231, 139, 139, 56, 244, 63, 98, 179, 11, 62, 132, 221, 107, 32, 18, 72, 9, 52, 219, 119, 192, 70, 101, 9, 140, 81, 243, 122, 23, 121, 65, 7, 44, 238, 137, 148, 15, 7, 5, 12, 208, 196, 195, 113, 61, 67, 122, 44, 105, 249, 159, 26, 151, 2, 55, 10, 107, 192, 126, 208, 46, 237, 207, 140, 151, 30, 220, 39, 21, 235, 101, 252 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("fc958a8f-9605-4b72-824c-79ff1b9a27f6"), "", 5, "admin@milsat.com", "Admin", 0, new byte[] { 181, 34, 172, 3, 86, 186, 25, 97, 153, 121, 37, 221, 204, 96, 38, 75, 118, 215, 127, 236, 208, 98, 160, 103, 128, 145, 174, 79, 159, 11, 12, 26, 218, 104, 74, 8, 57, 112, 9, 168, 77, 110, 171, 215, 225, 147, 227, 68, 181, 9, 61, 231, 130, 48, 234, 71, 149, 2, 35, 201, 243, 226, 51, 151 }, new byte[] { 32, 221, 212, 181, 214, 84, 43, 0, 40, 24, 31, 60, 131, 240, 192, 221, 204, 131, 231, 124, 204, 82, 160, 52, 33, 76, 204, 29, 244, 226, 10, 133, 235, 128, 44, 56, 83, 158, 225, 82, 79, 236, 27, 155, 212, 76, 195, 185, 148, 94, 125, 54, 85, 71, 60, 234, 166, 86, 201, 177, 150, 65, 93, 173, 253, 68, 86, 105, 2, 87, 112, 74, 200, 126, 0, 23, 28, 84, 152, 138, 76, 118, 240, 133, 99, 238, 8, 176, 140, 140, 40, 139, 60, 202, 193, 5, 49, 146, 88, 218, 59, 92, 37, 223, 219, 182, 229, 28, 205, 48, 113, 249, 199, 199, 140, 85, 110, 185, 204, 130, 21, 51, 133, 98, 232, 178, 157, 60 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("8a89f847-9d2e-482d-b3e7-bc0efffb4419"), new DateTime(2022, 9, 23, 12, 18, 18, 776, DateTimeKind.Utc).AddTicks(354), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("f7446f14-f6f2-4df6-bc26-5618ff050b98"), new DateTime(2022, 9, 23, 12, 18, 18, 776, DateTimeKind.Utc).AddTicks(352), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Intern_MentorId",
                table: "Intern",
                column: "MentorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intern");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
