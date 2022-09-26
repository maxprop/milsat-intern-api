using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class setnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("8a89f847-9d2e-482d-b3e7-bc0efffb4419"));

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("f7446f14-f6f2-4df6-bc26-5618ff050b98"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("fc958a8f-9605-4b72-824c-79ff1b9a27f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8a89f847-9d2e-482d-b3e7-bc0efffb4419"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f7446f14-f6f2-4df6-bc26-5618ff050b98"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("000135bd-b67f-4216-9110-bc5988187ba8"), "", 0, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 154, 107, 51, 175, 71, 31, 86, 171, 223, 145, 98, 194, 251, 37, 74, 178, 25, 72, 105, 42, 174, 237, 196, 241, 1, 237, 113, 9, 206, 106, 241, 8, 32, 185, 74, 120, 215, 18, 104, 240, 57, 45, 72, 16, 147, 31, 247, 7, 238, 37, 228, 73, 179, 26, 203, 176, 52, 219, 190, 132, 56, 229, 89, 127 }, new byte[] { 225, 91, 180, 37, 102, 98, 107, 74, 144, 196, 206, 194, 125, 93, 66, 133, 219, 142, 201, 106, 108, 119, 214, 204, 245, 36, 66, 154, 181, 96, 207, 137, 222, 17, 192, 42, 255, 27, 85, 18, 253, 245, 93, 98, 134, 168, 123, 146, 28, 89, 139, 236, 223, 73, 194, 89, 238, 16, 243, 162, 137, 50, 224, 75, 75, 153, 97, 130, 82, 127, 62, 235, 37, 66, 252, 210, 90, 10, 130, 167, 216, 112, 39, 107, 28, 114, 157, 137, 25, 35, 167, 171, 79, 146, 16, 118, 71, 13, 103, 172, 110, 45, 129, 87, 192, 135, 34, 63, 86, 143, 152, 117, 128, 152, 149, 227, 30, 230, 199, 116, 46, 18, 174, 48, 54, 135, 213, 172 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("383d0e75-7e9b-4d40-9187-bd3fea0399e1"), "", 5, "admin@milsat.com", "Admin", 0, new byte[] { 136, 225, 171, 13, 52, 55, 68, 253, 25, 64, 84, 215, 234, 132, 115, 250, 220, 147, 231, 201, 217, 211, 245, 45, 50, 11, 239, 75, 31, 237, 179, 249, 101, 202, 65, 55, 64, 214, 173, 161, 236, 111, 50, 212, 203, 106, 114, 231, 103, 181, 13, 113, 65, 191, 151, 139, 135, 160, 105, 230, 39, 146, 197, 36 }, new byte[] { 0, 93, 119, 175, 163, 12, 129, 236, 127, 142, 115, 96, 189, 17, 140, 140, 126, 21, 28, 93, 166, 39, 84, 39, 248, 179, 35, 110, 19, 125, 147, 105, 94, 179, 109, 203, 209, 195, 167, 162, 31, 7, 10, 134, 225, 34, 33, 23, 88, 178, 1, 40, 160, 171, 127, 170, 87, 177, 231, 48, 52, 165, 90, 122, 35, 215, 98, 222, 147, 150, 231, 88, 49, 94, 182, 212, 76, 163, 208, 174, 191, 121, 73, 233, 193, 89, 236, 204, 132, 194, 161, 255, 36, 26, 225, 155, 203, 246, 170, 203, 91, 27, 199, 98, 231, 105, 226, 124, 233, 255, 85, 238, 182, 207, 118, 74, 126, 248, 142, 229, 135, 29, 176, 172, 151, 178, 209, 49 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("bd4b3ae7-63ca-47d4-995d-b94878dcaad5"), "", 0, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 182, 140, 130, 45, 169, 12, 179, 211, 92, 122, 148, 73, 220, 28, 30, 87, 6, 161, 169, 51, 140, 80, 3, 225, 182, 124, 239, 162, 84, 250, 9, 150, 118, 3, 59, 199, 232, 205, 158, 50, 140, 159, 32, 13, 228, 184, 110, 105, 206, 245, 125, 105, 79, 44, 79, 6, 129, 127, 93, 117, 248, 113, 42, 184 }, new byte[] { 232, 181, 85, 167, 119, 88, 199, 248, 91, 163, 47, 94, 236, 142, 129, 80, 150, 116, 152, 136, 211, 82, 196, 10, 72, 204, 135, 160, 86, 248, 36, 191, 74, 176, 104, 27, 83, 90, 74, 218, 203, 53, 222, 93, 112, 97, 36, 222, 172, 240, 213, 45, 236, 101, 76, 139, 145, 49, 199, 27, 69, 202, 211, 245, 231, 112, 145, 242, 134, 168, 42, 141, 171, 154, 120, 4, 164, 241, 220, 192, 76, 170, 232, 214, 31, 104, 137, 51, 1, 40, 16, 143, 176, 238, 60, 104, 35, 238, 212, 16, 147, 202, 118, 178, 140, 239, 152, 56, 149, 106, 138, 49, 176, 96, 86, 219, 115, 249, 93, 147, 52, 196, 139, 39, 169, 202, 28, 146 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("000135bd-b67f-4216-9110-bc5988187ba8"), new DateTime(2022, 9, 26, 13, 9, 11, 822, DateTimeKind.Utc).AddTicks(5478), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("bd4b3ae7-63ca-47d4-995d-b94878dcaad5"), new DateTime(2022, 9, 26, 13, 9, 11, 822, DateTimeKind.Utc).AddTicks(5476), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("000135bd-b67f-4216-9110-bc5988187ba8"));

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("bd4b3ae7-63ca-47d4-995d-b94878dcaad5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("383d0e75-7e9b-4d40-9187-bd3fea0399e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("000135bd-b67f-4216-9110-bc5988187ba8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("bd4b3ae7-63ca-47d4-995d-b94878dcaad5"));

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
        }
    }
}
