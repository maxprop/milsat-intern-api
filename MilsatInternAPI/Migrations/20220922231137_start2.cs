using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("055004a1-92f9-46a0-9646-8bb1398e8d7b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("1cc2a7ba-b24d-4b87-962f-16d677767037"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ba7720c3-d86f-4865-a55b-80aa8a7a0553"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Mentor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2022, 9, 22, 23, 4, 20, 639, DateTimeKind.Utc).AddTicks(5894), new Guid("ba7720c3-d86f-4865-a55b-80aa8a7a0553") });

            migrationBuilder.UpdateData(
                table: "Mentor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UserId" },
                values: new object[] { new DateTime(2022, 9, 22, 23, 4, 20, 639, DateTimeKind.Utc).AddTicks(5896), new Guid("1cc2a7ba-b24d-4b87-962f-16d677767037") });
        }
    }
}
