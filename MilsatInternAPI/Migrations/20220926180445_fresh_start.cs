using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class fresh_start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfilePicture = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: false),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseOfStudy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Institution = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MentorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("4d0eb4fb-e2ad-4b78-b94f-ed56554d01ed"), "", 0, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 16, 167, 91, 159, 165, 200, 45, 146, 210, 23, 69, 145, 199, 83, 50, 90, 35, 137, 166, 116, 24, 75, 117, 143, 22, 221, 2, 98, 126, 228, 240, 81, 39, 99, 111, 72, 248, 141, 194, 167, 193, 79, 252, 19, 168, 48, 4, 110, 93, 93, 92, 156, 204, 28, 158, 201, 254, 136, 241, 26, 69, 108, 125, 44 }, new byte[] { 236, 170, 57, 158, 129, 139, 95, 87, 216, 244, 200, 150, 172, 229, 91, 245, 73, 205, 201, 25, 156, 253, 29, 0, 37, 188, 96, 123, 194, 209, 131, 238, 21, 106, 238, 14, 214, 60, 219, 34, 144, 195, 52, 153, 134, 221, 90, 208, 10, 44, 30, 74, 195, 182, 122, 3, 6, 155, 33, 148, 60, 95, 239, 69, 149, 223, 103, 40, 230, 142, 95, 49, 36, 160, 229, 211, 145, 53, 169, 223, 164, 141, 130, 152, 100, 62, 58, 47, 114, 68, 162, 14, 190, 72, 47, 90, 37, 13, 177, 113, 123, 136, 222, 216, 120, 38, 194, 86, 142, 43, 47, 6, 239, 32, 209, 82, 170, 131, 212, 21, 207, 250, 191, 183, 161, 227, 130, 219 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("54ba06eb-1064-4b23-9bb6-27efcdb1dbd9"), "", 0, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 34, 69, 26, 95, 45, 95, 209, 50, 193, 193, 243, 198, 157, 41, 39, 222, 210, 206, 2, 7, 54, 156, 242, 211, 15, 71, 78, 133, 17, 14, 223, 3, 180, 170, 212, 6, 100, 211, 79, 29, 27, 116, 84, 18, 75, 158, 195, 149, 121, 0, 73, 186, 134, 126, 233, 109, 50, 197, 15, 17, 40, 64, 252, 58 }, new byte[] { 159, 12, 101, 118, 99, 202, 213, 170, 169, 80, 146, 192, 173, 230, 198, 172, 19, 158, 108, 57, 163, 149, 46, 9, 47, 24, 142, 123, 69, 48, 84, 83, 22, 62, 51, 18, 6, 190, 250, 224, 24, 136, 214, 145, 143, 133, 65, 248, 139, 17, 71, 77, 170, 138, 253, 217, 190, 19, 122, 174, 185, 137, 171, 63, 196, 133, 175, 191, 181, 156, 18, 139, 226, 161, 63, 136, 59, 39, 102, 232, 238, 68, 230, 103, 142, 148, 183, 223, 220, 33, 93, 250, 241, 197, 176, 75, 83, 137, 94, 114, 225, 141, 56, 0, 117, 192, 252, 10, 217, 62, 131, 192, 84, 96, 67, 141, 42, 229, 179, 140, 18, 197, 89, 126, 119, 125, 102, 9 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("5924cfc8-25ca-44e6-9c51-435b1b76eca6"), "", 5, "admin@milsat.com", "Admin", 0, new byte[] { 123, 132, 53, 76, 91, 28, 64, 61, 116, 146, 90, 169, 208, 108, 112, 12, 182, 67, 106, 178, 194, 226, 39, 120, 133, 108, 93, 233, 221, 192, 12, 170, 97, 219, 18, 8, 64, 228, 80, 118, 203, 86, 221, 35, 255, 233, 48, 69, 222, 46, 76, 201, 65, 46, 161, 178, 85, 81, 19, 8, 189, 142, 39, 171 }, new byte[] { 182, 126, 125, 132, 77, 198, 4, 111, 66, 200, 15, 172, 169, 132, 206, 142, 89, 61, 149, 214, 67, 34, 124, 186, 196, 81, 186, 42, 14, 219, 197, 120, 71, 248, 35, 63, 92, 187, 194, 56, 138, 65, 172, 22, 91, 20, 204, 59, 26, 82, 171, 218, 200, 182, 214, 56, 176, 15, 136, 10, 109, 64, 228, 82, 190, 221, 91, 116, 170, 153, 215, 253, 144, 146, 91, 128, 126, 139, 131, 167, 194, 242, 12, 34, 190, 179, 67, 194, 125, 255, 229, 152, 49, 186, 196, 243, 154, 79, 128, 32, 59, 204, 248, 222, 68, 172, 25, 46, 119, 79, 69, 76, 169, 171, 67, 176, 118, 32, 79, 228, 80, 78, 28, 240, 162, 8, 130, 52 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("4d0eb4fb-e2ad-4b78-b94f-ed56554d01ed"), new DateTime(2022, 9, 26, 18, 4, 44, 919, DateTimeKind.Utc).AddTicks(4003), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("54ba06eb-1064-4b23-9bb6-27efcdb1dbd9"), new DateTime(2022, 9, 26, 18, 4, 44, 919, DateTimeKind.Utc).AddTicks(4005), 0 });

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
