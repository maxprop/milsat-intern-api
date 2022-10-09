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
                    PasswordResetToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordTokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordResetToken", "PasswordSalt", "PasswordTokenExpires", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires", "isDeleted" },
                values: new object[] { new Guid("029c4009-88e6-496f-8bab-78c8a2692d16"), "", 0, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 251, 121, 15, 145, 42, 77, 169, 217, 26, 75, 90, 174, 131, 15, 185, 115, 42, 189, 241, 153, 48, 161, 252, 120, 221, 163, 212, 28, 234, 24, 26, 102, 13, 66, 113, 230, 207, 111, 6, 28, 151, 165, 129, 251, 205, 49, 10, 80, 41, 217, 173, 96, 152, 149, 45, 81, 133, 189, 184, 33, 75, 149, 218, 225 }, null, new byte[] { 19, 139, 165, 195, 132, 205, 249, 91, 28, 246, 75, 238, 152, 12, 2, 113, 210, 22, 228, 207, 83, 101, 64, 11, 97, 173, 220, 23, 201, 159, 78, 47, 60, 63, 246, 116, 51, 19, 221, 155, 159, 72, 2, 161, 181, 237, 127, 72, 113, 7, 106, 176, 222, 26, 227, 38, 46, 210, 201, 129, 209, 200, 111, 228, 18, 152, 214, 108, 183, 214, 110, 225, 190, 103, 245, 41, 201, 99, 81, 200, 113, 95, 123, 115, 119, 207, 198, 13, 89, 188, 220, 141, 233, 122, 41, 87, 155, 9, 229, 238, 144, 208, 140, 176, 46, 11, 6, 242, 14, 12, 105, 78, 33, 185, 204, 51, 45, 205, 126, 132, 79, 225, 164, 156, 186, 89, 251, 39 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "passwords", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordResetToken", "PasswordSalt", "PasswordTokenExpires", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires", "isDeleted" },
                values: new object[] { new Guid("4a522966-4e85-4212-9302-ef1a68038653"), "", 0, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 140, 38, 120, 80, 11, 229, 240, 215, 47, 238, 89, 175, 36, 118, 123, 80, 26, 68, 197, 230, 160, 25, 65, 34, 85, 149, 168, 88, 150, 6, 15, 31, 241, 170, 246, 75, 101, 232, 128, 224, 209, 141, 79, 23, 123, 207, 109, 91, 165, 70, 160, 157, 18, 200, 5, 127, 215, 55, 10, 248, 211, 79, 29, 229 }, null, new byte[] { 164, 158, 42, 86, 113, 234, 85, 195, 194, 125, 233, 16, 39, 229, 238, 84, 130, 54, 214, 51, 170, 139, 76, 9, 122, 119, 59, 194, 179, 62, 34, 136, 136, 19, 186, 77, 223, 151, 210, 59, 106, 160, 140, 122, 165, 244, 124, 14, 79, 209, 195, 17, 0, 18, 57, 74, 159, 141, 4, 117, 92, 39, 196, 110, 160, 201, 195, 96, 79, 218, 214, 232, 242, 60, 98, 182, 105, 28, 68, 118, 214, 45, 208, 216, 197, 18, 71, 145, 213, 100, 125, 108, 170, 161, 198, 203, 213, 161, 63, 53, 201, 250, 129, 194, 160, 143, 83, 145, 246, 138, 15, 203, 36, 130, 222, 23, 181, 26, 65, 210, 46, 7, 57, 22, 112, 254, 211, 112 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "passwords", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordResetToken", "PasswordSalt", "PasswordTokenExpires", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires", "isDeleted" },
                values: new object[] { new Guid("ba759bfb-59b5-49a1-850f-1d1f5ba270df"), "", 5, "admin@milsat.com", "Admin", 0, new byte[] { 244, 2, 39, 184, 215, 255, 70, 93, 151, 114, 169, 11, 215, 145, 232, 201, 221, 68, 58, 193, 150, 14, 111, 145, 50, 78, 66, 210, 12, 211, 62, 76, 245, 3, 10, 205, 65, 173, 152, 164, 212, 102, 125, 75, 253, 200, 37, 87, 34, 63, 110, 67, 57, 124, 199, 89, 193, 25, 118, 216, 132, 132, 247, 87 }, null, new byte[] { 48, 126, 156, 171, 74, 58, 188, 250, 234, 60, 69, 187, 10, 32, 187, 177, 45, 37, 32, 181, 25, 217, 6, 157, 251, 246, 7, 148, 249, 12, 6, 14, 252, 173, 202, 89, 130, 196, 226, 251, 183, 108, 199, 27, 254, 231, 170, 158, 125, 131, 20, 118, 18, 54, 227, 108, 2, 28, 189, 85, 188, 100, 68, 128, 239, 159, 194, 197, 147, 243, 251, 171, 212, 59, 99, 50, 7, 242, 138, 70, 240, 212, 95, 205, 221, 210, 23, 39, 42, 135, 82, 222, 115, 97, 239, 40, 37, 225, 33, 91, 223, 177, 188, 125, 60, 39, 0, 147, 244, 201, 110, 214, 8, 164, 138, 102, 202, 201, 182, 182, 128, 211, 54, 71, 145, 4, 146, 214 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "datasolutions", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("029c4009-88e6-496f-8bab-78c8a2692d16"), new DateTime(2022, 10, 7, 15, 15, 18, 679, DateTimeKind.Utc).AddTicks(1222), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("4a522966-4e85-4212-9302-ef1a68038653"), new DateTime(2022, 10, 7, 15, 15, 18, 679, DateTimeKind.Utc).AddTicks(1225), 0 });

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
