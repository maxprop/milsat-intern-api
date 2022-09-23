using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class start3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Mentor_MentorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MentorId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("61c0d488-71d4-4db8-aaf6-4dcee14985a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("96a7892b-f8b3-4384-9c81-e3e2c7ebd883"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d3baa9dd-146a-4e30-89c1-e49bd8aefd19"));

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "MentorId1",
                table: "Intern",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("747cc885-aaea-43db-85aa-c47168d05bdb"), "", 1, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 223, 221, 5, 145, 241, 229, 85, 234, 210, 27, 51, 34, 18, 156, 226, 246, 138, 161, 119, 115, 222, 188, 238, 171, 68, 44, 217, 89, 146, 12, 126, 233, 66, 118, 22, 162, 32, 246, 239, 171, 166, 38, 159, 255, 244, 238, 214, 94, 53, 26, 207, 253, 39, 120, 113, 185, 211, 3, 255, 123, 138, 2, 236, 178 }, new byte[] { 75, 73, 45, 136, 51, 151, 189, 152, 133, 202, 41, 41, 113, 241, 69, 160, 26, 134, 26, 212, 159, 84, 177, 146, 162, 12, 166, 63, 163, 112, 221, 126, 18, 57, 9, 73, 150, 55, 108, 37, 43, 122, 124, 134, 25, 184, 39, 155, 71, 33, 112, 123, 252, 195, 112, 38, 182, 226, 231, 67, 50, 177, 194, 43, 181, 112, 220, 126, 255, 247, 191, 228, 246, 181, 107, 157, 131, 246, 156, 146, 86, 188, 9, 84, 69, 148, 141, 158, 185, 232, 127, 103, 115, 202, 131, 52, 114, 101, 170, 49, 182, 249, 54, 131, 19, 195, 92, 193, 165, 243, 40, 172, 81, 161, 19, 162, 100, 28, 73, 88, 36, 227, 227, 47, 234, 18, 237, 118 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("d09230de-e3a0-49a8-8893-fe7906d895fc"), "", 1, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 7, 198, 90, 23, 210, 96, 172, 238, 49, 130, 58, 234, 215, 211, 219, 10, 9, 120, 124, 59, 30, 101, 162, 175, 122, 138, 30, 249, 166, 118, 43, 32, 142, 205, 56, 151, 9, 255, 187, 219, 91, 77, 186, 57, 20, 249, 188, 149, 153, 159, 156, 97, 134, 158, 172, 55, 192, 251, 184, 183, 17, 190, 122, 247 }, new byte[] { 109, 133, 75, 1, 219, 255, 143, 160, 114, 71, 97, 243, 56, 235, 22, 180, 74, 12, 216, 209, 221, 51, 216, 197, 119, 139, 108, 194, 210, 138, 231, 180, 61, 6, 114, 101, 140, 137, 28, 38, 72, 174, 175, 71, 238, 61, 54, 242, 172, 44, 72, 217, 231, 160, 24, 3, 191, 21, 187, 200, 87, 186, 71, 160, 104, 190, 50, 184, 70, 129, 56, 249, 169, 118, 234, 47, 161, 125, 10, 228, 22, 79, 126, 24, 103, 155, 73, 240, 137, 55, 124, 141, 123, 148, 114, 37, 203, 122, 76, 232, 207, 92, 109, 208, 252, 183, 159, 122, 180, 24, 105, 103, 96, 190, 83, 17, 192, 17, 235, 24, 238, 123, 159, 213, 81, 55, 143, 49 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("f80584c0-b27e-422b-8b5d-192a2895a567"), "", 6, "admin@milsat.com", "Admin", 0, new byte[] { 117, 65, 187, 111, 45, 31, 112, 226, 16, 138, 154, 134, 98, 213, 255, 85, 124, 208, 53, 52, 237, 3, 60, 24, 70, 185, 114, 204, 239, 11, 13, 35, 149, 224, 56, 9, 181, 219, 19, 182, 163, 78, 190, 43, 148, 186, 25, 31, 235, 249, 98, 211, 196, 167, 154, 55, 104, 186, 163, 159, 65, 28, 198, 228 }, new byte[] { 185, 157, 136, 37, 130, 177, 169, 80, 238, 160, 139, 201, 154, 129, 59, 62, 85, 99, 146, 103, 116, 62, 193, 234, 147, 189, 28, 83, 69, 89, 91, 171, 167, 146, 193, 189, 17, 108, 241, 200, 160, 181, 124, 245, 45, 121, 64, 182, 141, 17, 165, 89, 226, 43, 47, 51, 195, 69, 248, 79, 226, 67, 97, 10, 96, 129, 231, 184, 238, 7, 110, 200, 228, 236, 109, 0, 139, 30, 95, 251, 180, 82, 11, 213, 112, 105, 182, 234, 249, 1, 216, 209, 35, 217, 100, 14, 56, 102, 7, 168, 126, 29, 112, 79, 50, 218, 242, 87, 129, 187, 215, 187, 109, 166, 187, 228, 154, 232, 232, 189, 46, 24, 219, 116, 174, 224, 209, 142 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mentor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2022, 9, 22, 23, 16, 39, 57, DateTimeKind.Utc).AddTicks(5503), new Guid("747cc885-aaea-43db-85aa-c47168d05bdb") });

            migrationBuilder.UpdateData(
                table: "Mentor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2022, 9, 22, 23, 16, 39, 57, DateTimeKind.Utc).AddTicks(5505), new Guid("d09230de-e3a0-49a8-8893-fe7906d895fc") });

            migrationBuilder.CreateIndex(
                name: "IX_Intern_MentorId1",
                table: "Intern",
                column: "MentorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Mentor_MentorId1",
                table: "Intern",
                column: "MentorId1",
                principalTable: "Mentor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Mentor_MentorId1",
                table: "Intern");

            migrationBuilder.DropIndex(
                name: "IX_Intern_MentorId1",
                table: "Intern");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("747cc885-aaea-43db-85aa-c47168d05bdb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d09230de-e3a0-49a8-8893-fe7906d895fc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f80584c0-b27e-422b-8b5d-192a2895a567"));

            migrationBuilder.DropColumn(
                name: "MentorId1",
                table: "Intern");

            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "MentorId", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("61c0d488-71d4-4db8-aaf6-4dcee14985a5"), "", 1, "mentor1@gmail.com", "Sodiq Agboola", 0, null, new byte[] { 56, 227, 77, 190, 253, 135, 234, 106, 18, 170, 188, 163, 195, 227, 230, 61, 169, 51, 83, 171, 109, 40, 55, 239, 219, 11, 240, 81, 168, 178, 55, 83, 34, 137, 67, 122, 45, 41, 201, 125, 126, 180, 60, 160, 49, 189, 162, 174, 123, 16, 189, 103, 246, 150, 94, 162, 165, 9, 133, 209, 80, 12, 129, 102 }, new byte[] { 188, 216, 190, 95, 207, 94, 172, 112, 101, 38, 157, 122, 47, 109, 158, 220, 54, 22, 50, 136, 47, 37, 248, 243, 159, 176, 47, 164, 105, 95, 32, 167, 17, 234, 155, 19, 162, 11, 86, 124, 234, 68, 163, 226, 73, 251, 116, 52, 222, 139, 6, 192, 226, 166, 97, 37, 177, 214, 131, 13, 188, 89, 110, 86, 70, 239, 227, 39, 244, 132, 71, 95, 176, 106, 27, 145, 233, 5, 157, 168, 187, 164, 7, 207, 66, 121, 45, 153, 92, 82, 203, 182, 143, 189, 173, 129, 248, 114, 75, 71, 96, 31, 128, 171, 125, 20, 191, 130, 111, 72, 236, 62, 165, 17, 45, 194, 96, 49, 155, 93, 41, 25, 67, 134, 213, 192, 56, 234 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "MentorId", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("96a7892b-f8b3-4384-9c81-e3e2c7ebd883"), "", 1, "mentor2@gmail.com", "Sodiq Agboola", 0, null, new byte[] { 217, 244, 95, 186, 92, 93, 54, 100, 200, 51, 85, 136, 120, 97, 222, 105, 83, 58, 158, 217, 157, 59, 38, 170, 55, 58, 59, 217, 10, 137, 55, 103, 189, 90, 59, 137, 244, 133, 44, 161, 192, 17, 200, 7, 190, 49, 28, 198, 47, 119, 36, 42, 197, 45, 79, 68, 230, 250, 108, 247, 80, 193, 62, 38 }, new byte[] { 159, 20, 5, 54, 123, 79, 237, 93, 155, 156, 128, 28, 103, 94, 234, 190, 155, 72, 2, 212, 109, 66, 115, 95, 87, 17, 189, 93, 155, 19, 5, 89, 213, 232, 132, 238, 155, 207, 238, 114, 238, 163, 3, 42, 15, 20, 168, 216, 246, 224, 138, 13, 120, 252, 5, 67, 184, 26, 11, 81, 191, 196, 64, 74, 35, 51, 15, 103, 182, 42, 174, 128, 100, 57, 14, 92, 185, 200, 197, 26, 139, 243, 71, 50, 182, 133, 14, 68, 38, 84, 135, 105, 47, 246, 181, 191, 6, 214, 28, 163, 59, 120, 186, 185, 51, 208, 78, 67, 109, 233, 99, 170, 162, 0, 152, 178, 108, 3, 248, 186, 213, 157, 76, 21, 94, 1, 82, 70 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "MentorId", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("d3baa9dd-146a-4e30-89c1-e49bd8aefd19"), "", 6, "admin@milsat.com", "Admin", 0, null, new byte[] { 60, 122, 37, 234, 177, 95, 31, 80, 207, 24, 82, 50, 254, 78, 20, 236, 122, 124, 175, 108, 175, 190, 109, 215, 63, 101, 142, 63, 48, 44, 188, 11, 190, 222, 47, 218, 43, 174, 46, 125, 24, 184, 148, 149, 27, 95, 178, 87, 194, 69, 73, 171, 1, 254, 18, 171, 186, 70, 136, 101, 196, 28, 52, 168 }, new byte[] { 200, 210, 134, 137, 226, 197, 202, 235, 70, 123, 6, 57, 72, 21, 205, 174, 176, 94, 132, 137, 175, 197, 87, 23, 93, 55, 109, 57, 48, 66, 66, 33, 75, 15, 84, 100, 63, 140, 170, 91, 199, 222, 137, 222, 186, 2, 8, 51, 48, 80, 78, 112, 130, 238, 38, 157, 31, 176, 224, 254, 93, 58, 6, 13, 83, 85, 92, 72, 211, 85, 201, 54, 197, 97, 26, 91, 235, 10, 9, 8, 159, 81, 73, 220, 48, 160, 189, 38, 198, 55, 212, 216, 12, 21, 125, 121, 189, 96, 187, 72, 66, 40, 32, 213, 167, 248, 147, 164, 117, 115, 167, 139, 7, 128, 107, 55, 127, 6, 82, 243, 140, 43, 30, 50, 81, 185, 79, 59 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Mentor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2022, 9, 22, 23, 11, 37, 390, DateTimeKind.Utc).AddTicks(1757), new Guid("61c0d488-71d4-4db8-aaf6-4dcee14985a5") });

            migrationBuilder.UpdateData(
                table: "Mentor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2022, 9, 22, 23, 11, 37, 390, DateTimeKind.Utc).AddTicks(1759), new Guid("96a7892b-f8b3-4384-9c81-e3e2c7ebd883") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MentorId",
                table: "Users",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Mentor_MentorId",
                table: "Users",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id");
        }
    }
}
