using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class testmysql : Migration
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
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    MentorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.MentorId);
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
                    InternId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MentorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.InternId);
                    table.ForeignKey(
                        name: "FK_Intern_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "MentorId");
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
                columns: new[] { "UserId", "Department", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("0a24644e-8b89-42ff-a0c9-59a13987ce74"), 6, "admin@milsat.com", "admin", "admin", new byte[] { 184, 193, 159, 188, 219, 93, 233, 98, 253, 44, 92, 202, 143, 85, 255, 155, 172, 149, 50, 107, 66, 76, 0, 4, 38, 129, 195, 23, 75, 201, 59, 99, 179, 187, 254, 98, 247, 16, 124, 38, 139, 163, 178, 190, 223, 85, 149, 250, 165, 183, 233, 228, 248, 201, 14, 132, 204, 53, 211, 13, 96, 46, 41, 51 }, new byte[] { 178, 125, 6, 73, 126, 119, 71, 42, 255, 122, 51, 131, 110, 140, 136, 38, 21, 27, 201, 143, 114, 213, 152, 25, 112, 26, 115, 237, 42, 0, 44, 66, 118, 84, 181, 31, 183, 247, 238, 89, 235, 99, 53, 167, 213, 77, 43, 111, 247, 243, 142, 8, 20, 164, 3, 213, 52, 198, 53, 42, 61, 122, 142, 49, 174, 117, 140, 181, 82, 245, 234, 71, 130, 227, 34, 12, 68, 21, 48, 128, 131, 249, 10, 178, 170, 116, 67, 73, 227, 219, 107, 69, 67, 47, 185, 25, 168, 98, 39, 143, 100, 99, 175, 155, 113, 238, 26, 154, 223, 52, 166, 89, 219, 59, 146, 204, 51, 63, 182, 246, 230, 119, 198, 50, 41, 35, 140, 144 }, "home", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Department", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("8cbdd6c2-2c0d-42f1-b2aa-41f4a25e4d33"), 1, "mentor2@gmail.com", "Sodiq", "Agboola", new byte[] { 143, 153, 224, 144, 192, 18, 20, 247, 164, 137, 182, 230, 56, 9, 129, 143, 196, 156, 68, 83, 125, 183, 49, 65, 1, 97, 224, 248, 146, 76, 212, 58, 22, 179, 36, 130, 115, 172, 240, 26, 1, 22, 68, 115, 186, 60, 148, 105, 61, 248, 21, 150, 152, 45, 127, 223, 188, 242, 234, 157, 246, 45, 33, 61 }, new byte[] { 160, 43, 140, 121, 175, 20, 235, 105, 68, 91, 207, 213, 65, 106, 205, 26, 141, 227, 40, 212, 152, 61, 18, 95, 157, 180, 98, 246, 130, 210, 140, 108, 17, 35, 126, 86, 195, 253, 203, 194, 150, 134, 146, 111, 130, 14, 14, 219, 212, 174, 22, 186, 55, 210, 201, 216, 134, 197, 178, 139, 123, 22, 177, 117, 237, 114, 137, 58, 210, 203, 19, 229, 163, 170, 154, 140, 179, 64, 128, 14, 192, 21, 70, 140, 178, 224, 243, 230, 113, 21, 210, 28, 190, 183, 20, 112, 169, 211, 214, 158, 201, 63, 86, 8, 78, 252, 110, 186, 164, 8, 254, 32, 128, 203, 122, 88, 240, 148, 40, 210, 65, 40, 144, 151, 255, 224, 178, 11 }, "string", null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Department", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("f3ef28d8-ff81-4447-9025-265d5c173686"), 1, "mentor1@gmail.com", "Sodiq", "Agboola", new byte[] { 122, 114, 197, 7, 0, 252, 241, 221, 236, 180, 206, 49, 29, 237, 246, 71, 45, 75, 203, 115, 6, 233, 163, 144, 61, 171, 209, 212, 163, 40, 152, 184, 54, 70, 165, 16, 101, 40, 252, 244, 84, 116, 31, 236, 34, 199, 224, 30, 115, 226, 40, 44, 237, 66, 64, 92, 251, 228, 190, 147, 55, 139, 255, 179 }, new byte[] { 174, 217, 244, 217, 8, 255, 46, 7, 50, 83, 56, 174, 217, 188, 147, 93, 122, 187, 92, 186, 70, 117, 104, 78, 114, 155, 200, 226, 52, 214, 105, 215, 171, 16, 13, 81, 147, 34, 237, 70, 247, 163, 92, 97, 226, 154, 148, 88, 66, 64, 105, 99, 133, 85, 210, 172, 109, 48, 241, 90, 103, 128, 57, 89, 186, 228, 55, 219, 46, 22, 145, 14, 93, 183, 74, 84, 176, 55, 204, 77, 243, 57, 86, 42, 69, 32, 226, 37, 113, 226, 197, 65, 102, 23, 32, 133, 88, 89, 95, 64, 139, 6, 219, 18, 159, 61, 229, 212, 24, 30, 176, 63, 26, 216, 95, 90, 163, 1, 46, 131, 133, 78, 101, 241, 183, 99, 213, 177 }, "string", null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "MentorId", "CreatedOn", "Status", "UserId" },
                values: new object[] { new Guid("899af72f-3a54-430b-accd-d9094fa1ba37"), new DateTime(2022, 9, 18, 14, 34, 55, 527, DateTimeKind.Utc).AddTicks(3752), 0, new Guid("f3ef28d8-ff81-4447-9025-265d5c173686") });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "MentorId", "CreatedOn", "Status", "UserId" },
                values: new object[] { new Guid("aa5f5c50-25ac-4210-bceb-4fdee58d1b7f"), new DateTime(2022, 9, 18, 14, 34, 55, 527, DateTimeKind.Utc).AddTicks(3770), 0, new Guid("8cbdd6c2-2c0d-42f1-b2aa-41f4a25e4d33") });

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
