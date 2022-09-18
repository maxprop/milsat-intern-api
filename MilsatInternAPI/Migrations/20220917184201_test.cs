using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Department", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("5acf5ea9-e20a-41cf-a14f-23862ed8487f"), 1, "mentor2@gmail.com", "Sodiq", "Agboola", new byte[] { 128, 170, 92, 126, 127, 106, 207, 239, 55, 0, 178, 25, 209, 119, 219, 12, 78, 103, 76, 216, 156, 57, 226, 192, 195, 181, 37, 1, 154, 179, 28, 114, 163, 56, 57, 58, 53, 4, 109, 177, 166, 190, 22, 233, 2, 80, 170, 81, 32, 241, 42, 72, 175, 184, 246, 209, 67, 224, 150, 121, 143, 25, 36, 208 }, new byte[] { 53, 33, 133, 0, 182, 70, 63, 215, 105, 33, 128, 59, 129, 178, 187, 226, 233, 210, 86, 33, 203, 200, 20, 25, 89, 185, 246, 27, 61, 217, 48, 232, 71, 252, 245, 135, 140, 233, 8, 233, 166, 213, 82, 147, 17, 102, 237, 94, 50, 156, 53, 166, 73, 183, 83, 187, 58, 189, 109, 231, 143, 147, 57, 211, 59, 59, 130, 222, 112, 250, 115, 20, 69, 46, 42, 7, 195, 181, 60, 87, 167, 20, 109, 84, 219, 219, 47, 243, 73, 22, 17, 211, 120, 163, 122, 96, 153, 191, 73, 36, 59, 193, 189, 32, 11, 218, 223, 50, 37, 208, 114, 147, 171, 174, 87, 69, 18, 221, 40, 118, 147, 239, 168, 125, 191, 177, 76, 119 }, "string", null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Department", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("90ae4160-d38f-4218-ad7f-4aae38493c30"), 1, "mentor1@gmail.com", "Sodiq", "Agboola", new byte[] { 184, 27, 185, 113, 38, 175, 160, 187, 109, 23, 206, 179, 140, 94, 103, 65, 83, 167, 251, 32, 100, 8, 141, 73, 250, 1, 141, 5, 111, 85, 221, 217, 157, 42, 58, 59, 228, 164, 117, 252, 19, 242, 37, 62, 247, 219, 79, 244, 157, 80, 192, 6, 214, 55, 237, 53, 175, 177, 225, 146, 2, 173, 27, 244 }, new byte[] { 215, 54, 126, 123, 33, 142, 49, 48, 164, 240, 123, 94, 239, 110, 179, 1, 48, 18, 112, 76, 34, 156, 132, 56, 57, 170, 71, 22, 11, 31, 23, 138, 182, 28, 33, 226, 161, 193, 15, 156, 153, 83, 210, 63, 30, 97, 195, 193, 57, 165, 131, 202, 234, 74, 89, 68, 8, 27, 135, 172, 120, 177, 90, 124, 225, 37, 236, 195, 98, 51, 87, 43, 169, 190, 123, 245, 195, 176, 99, 191, 16, 225, 88, 228, 71, 148, 81, 25, 144, 58, 219, 79, 72, 175, 108, 255, 143, 111, 185, 86, 86, 92, 181, 189, 173, 38, 182, 254, 66, 2, 103, 227, 223, 120, 29, 103, 254, 37, 78, 149, 128, 190, 131, 122, 72, 221, 214, 228 }, "string", null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Department", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("f2b20627-2886-45ca-bcc7-96810f7bdd92"), 6, "admin@milsat.com", "admin", "admin", new byte[] { 171, 188, 104, 114, 222, 179, 105, 151, 140, 217, 34, 121, 57, 55, 186, 59, 184, 104, 90, 196, 48, 235, 56, 148, 177, 95, 224, 172, 147, 181, 38, 254, 210, 157, 56, 248, 164, 48, 193, 140, 222, 4, 126, 41, 244, 170, 115, 145, 252, 63, 6, 183, 245, 108, 155, 177, 155, 4, 12, 86, 168, 177, 250, 209 }, new byte[] { 197, 94, 21, 196, 5, 155, 84, 3, 159, 205, 177, 69, 18, 194, 92, 34, 248, 43, 16, 71, 167, 165, 68, 152, 2, 185, 235, 46, 95, 234, 236, 103, 45, 193, 44, 186, 198, 112, 6, 209, 232, 221, 49, 235, 224, 228, 70, 61, 88, 85, 120, 165, 240, 89, 22, 192, 94, 140, 178, 67, 102, 71, 131, 26, 243, 70, 115, 169, 138, 157, 78, 193, 50, 65, 64, 69, 207, 105, 84, 121, 179, 43, 248, 20, 142, 106, 199, 176, 219, 56, 84, 238, 106, 159, 80, 49, 11, 36, 20, 49, 232, 66, 152, 225, 251, 251, 234, 14, 132, 190, 227, 253, 45, 22, 78, 245, 187, 5, 72, 145, 81, 148, 175, 159, 144, 149, 41, 231 }, "home", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "MentorId", "CreatedOn", "Status", "UserId" },
                values: new object[] { new Guid("20d5c3fe-d2e5-454e-8446-30060188ccf1"), new DateTime(2022, 9, 17, 18, 42, 1, 533, DateTimeKind.Utc).AddTicks(8843), 0, new Guid("90ae4160-d38f-4218-ad7f-4aae38493c30") });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "MentorId", "CreatedOn", "Status", "UserId" },
                values: new object[] { new Guid("6b9f3d86-8863-4d25-9435-9285fee15b0a"), new DateTime(2022, 9, 17, 18, 42, 1, 533, DateTimeKind.Utc).AddTicks(8847), 0, new Guid("5acf5ea9-e20a-41cf-a14f-23862ed8487f") });

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
