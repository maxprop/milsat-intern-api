using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Mentor_MentorId",
                table: "Intern");

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("0ec2dc1d-b153-42f5-ba15-07b50b9d35e6"));

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("6408f79f-0813-4048-8843-a7a8d2f2ab7e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a0c20fa9-20b0-4aee-8642-60e7f55ab8dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0ec2dc1d-b153-42f5-ba15-07b50b9d35e6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("6408f79f-0813-4048-8843-a7a8d2f2ab7e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("45be124e-b908-45ba-b5ba-8afb698659bb"), "", 0, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 83, 59, 25, 103, 225, 41, 104, 174, 99, 71, 70, 231, 90, 137, 131, 169, 105, 83, 33, 231, 155, 12, 90, 200, 227, 130, 75, 50, 108, 167, 241, 190, 31, 5, 202, 72, 102, 242, 70, 49, 111, 122, 172, 71, 172, 133, 156, 116, 165, 164, 12, 206, 3, 13, 176, 164, 109, 6, 226, 207, 99, 2, 250, 251 }, new byte[] { 250, 123, 201, 220, 182, 155, 117, 238, 233, 44, 211, 140, 88, 182, 201, 69, 235, 169, 97, 156, 146, 222, 129, 181, 186, 52, 53, 66, 206, 79, 104, 99, 10, 144, 24, 122, 103, 223, 244, 237, 166, 249, 231, 244, 104, 58, 154, 126, 95, 12, 168, 187, 182, 44, 39, 107, 123, 189, 178, 100, 17, 104, 214, 79, 13, 170, 192, 77, 109, 31, 172, 4, 149, 143, 49, 219, 116, 15, 142, 205, 69, 200, 143, 236, 122, 50, 231, 245, 0, 236, 197, 148, 8, 91, 178, 234, 160, 155, 126, 251, 167, 26, 131, 100, 140, 224, 235, 145, 192, 103, 227, 109, 246, 137, 235, 50, 59, 141, 181, 140, 125, 62, 43, 29, 130, 27, 119, 151 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("56128474-b5d6-4a4a-87ee-1880cd23a1f4"), "", 0, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 210, 7, 129, 184, 102, 138, 126, 214, 183, 190, 250, 79, 71, 234, 254, 14, 255, 239, 179, 60, 30, 44, 116, 132, 176, 6, 186, 46, 151, 59, 114, 229, 49, 42, 109, 157, 141, 73, 76, 9, 46, 85, 116, 123, 211, 151, 88, 211, 139, 139, 92, 208, 6, 7, 20, 208, 235, 126, 166, 151, 99, 204, 129, 79 }, new byte[] { 17, 9, 219, 98, 6, 62, 115, 142, 235, 27, 252, 95, 188, 183, 6, 129, 127, 52, 184, 50, 192, 90, 228, 154, 78, 81, 28, 179, 1, 68, 206, 77, 104, 191, 191, 117, 98, 29, 199, 172, 154, 146, 60, 10, 148, 176, 242, 168, 52, 133, 86, 79, 10, 199, 84, 238, 72, 75, 196, 20, 96, 231, 172, 37, 122, 143, 179, 3, 183, 70, 46, 137, 239, 47, 154, 127, 255, 77, 113, 1, 229, 177, 56, 242, 59, 190, 105, 221, 89, 221, 29, 204, 231, 73, 42, 231, 122, 59, 31, 33, 84, 227, 56, 3, 226, 172, 221, 153, 19, 188, 185, 131, 19, 14, 4, 62, 185, 107, 171, 133, 123, 227, 114, 154, 137, 1, 136, 145 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("ce9af307-1103-4429-9b83-9d07095fbc1e"), "", 5, "admin@milsat.com", "Admin", 0, new byte[] { 1, 2, 33, 206, 247, 10, 146, 70, 3, 151, 236, 159, 199, 12, 207, 163, 191, 168, 128, 180, 214, 83, 113, 89, 29, 0, 92, 40, 88, 120, 7, 34, 120, 248, 198, 131, 45, 78, 163, 179, 154, 139, 208, 78, 244, 145, 113, 12, 220, 112, 154, 33, 55, 227, 131, 46, 116, 221, 233, 183, 74, 187, 159, 83 }, new byte[] { 240, 84, 29, 27, 121, 243, 237, 112, 72, 218, 78, 6, 254, 63, 107, 244, 245, 194, 169, 138, 98, 108, 99, 96, 251, 20, 178, 62, 94, 145, 101, 75, 148, 98, 100, 102, 13, 154, 49, 73, 22, 199, 70, 198, 114, 239, 63, 210, 95, 12, 140, 252, 13, 76, 110, 131, 91, 168, 36, 83, 110, 148, 100, 153, 131, 111, 169, 223, 183, 120, 217, 191, 193, 18, 92, 42, 80, 51, 50, 149, 138, 82, 110, 121, 54, 161, 9, 106, 126, 237, 41, 150, 80, 157, 212, 176, 8, 26, 80, 202, 185, 161, 245, 63, 156, 179, 203, 139, 219, 164, 45, 96, 135, 61, 204, 144, 98, 24, 207, 188, 244, 21, 70, 43, 191, 64, 31, 168 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("45be124e-b908-45ba-b5ba-8afb698659bb"), new DateTime(2022, 9, 23, 11, 55, 12, 891, DateTimeKind.Utc).AddTicks(9845), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("56128474-b5d6-4a4a-87ee-1880cd23a1f4"), new DateTime(2022, 9, 23, 11, 55, 12, 891, DateTimeKind.Utc).AddTicks(9847), 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Mentor_MentorId",
                table: "Intern",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Mentor_MentorId",
                table: "Intern");

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("45be124e-b908-45ba-b5ba-8afb698659bb"));

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("56128474-b5d6-4a4a-87ee-1880cd23a1f4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ce9af307-1103-4429-9b83-9d07095fbc1e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("45be124e-b908-45ba-b5ba-8afb698659bb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("56128474-b5d6-4a4a-87ee-1880cd23a1f4"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("0ec2dc1d-b153-42f5-ba15-07b50b9d35e6"), "", 0, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 122, 33, 245, 62, 68, 28, 250, 193, 32, 246, 244, 255, 222, 173, 57, 19, 192, 70, 52, 126, 221, 202, 3, 25, 7, 56, 37, 229, 90, 83, 227, 206, 198, 227, 205, 80, 18, 175, 53, 81, 6, 12, 160, 111, 123, 39, 165, 48, 161, 250, 178, 194, 89, 87, 154, 27, 115, 146, 69, 20, 76, 55, 243, 138 }, new byte[] { 5, 23, 74, 139, 231, 181, 53, 102, 175, 164, 197, 71, 218, 195, 208, 193, 181, 175, 146, 76, 85, 42, 212, 98, 29, 95, 165, 141, 121, 177, 59, 250, 62, 30, 148, 151, 242, 82, 164, 118, 192, 60, 194, 108, 13, 238, 75, 69, 113, 192, 246, 192, 153, 51, 71, 87, 31, 181, 9, 60, 55, 189, 206, 173, 227, 121, 47, 154, 159, 36, 44, 207, 34, 90, 243, 201, 174, 213, 21, 136, 6, 250, 173, 93, 192, 97, 20, 16, 160, 137, 212, 155, 51, 101, 18, 97, 37, 192, 122, 146, 73, 10, 244, 211, 240, 247, 175, 103, 223, 0, 242, 10, 4, 115, 164, 165, 81, 149, 192, 31, 145, 88, 241, 117, 202, 244, 131, 67 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("6408f79f-0813-4048-8843-a7a8d2f2ab7e"), "", 0, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 125, 139, 16, 124, 186, 226, 128, 189, 19, 194, 175, 153, 49, 173, 133, 104, 190, 81, 168, 237, 115, 104, 198, 209, 210, 240, 134, 79, 126, 72, 233, 36, 224, 180, 157, 91, 46, 56, 197, 199, 2, 239, 53, 237, 109, 16, 30, 134, 205, 174, 124, 142, 51, 220, 73, 223, 236, 249, 127, 153, 101, 32, 225, 20 }, new byte[] { 210, 203, 69, 186, 128, 229, 165, 98, 133, 115, 105, 225, 249, 227, 171, 33, 248, 95, 152, 127, 135, 61, 58, 238, 210, 88, 202, 101, 210, 100, 168, 136, 179, 133, 186, 24, 241, 3, 245, 110, 171, 136, 164, 88, 108, 180, 232, 47, 234, 219, 252, 148, 109, 93, 87, 3, 10, 43, 231, 227, 244, 179, 89, 232, 192, 178, 172, 43, 206, 192, 131, 146, 214, 212, 141, 95, 153, 246, 242, 25, 119, 53, 193, 247, 220, 25, 244, 153, 136, 136, 81, 218, 73, 112, 252, 177, 129, 41, 221, 172, 29, 16, 235, 45, 77, 15, 13, 8, 95, 234, 159, 249, 70, 103, 1, 122, 160, 44, 51, 237, 177, 99, 53, 111, 97, 15, 255, 241 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("a0c20fa9-20b0-4aee-8642-60e7f55ab8dc"), "", 5, "admin@milsat.com", "Admin", 0, new byte[] { 246, 57, 147, 191, 77, 233, 224, 88, 140, 185, 110, 77, 211, 64, 230, 185, 77, 75, 145, 155, 55, 30, 122, 114, 53, 64, 24, 156, 131, 147, 103, 186, 209, 40, 214, 100, 235, 9, 35, 141, 198, 9, 79, 193, 12, 104, 133, 62, 10, 220, 54, 162, 243, 69, 168, 78, 108, 75, 156, 203, 242, 123, 71, 168 }, new byte[] { 176, 254, 190, 3, 184, 109, 21, 180, 77, 209, 191, 254, 139, 136, 71, 121, 24, 169, 56, 81, 63, 150, 56, 194, 51, 57, 195, 189, 187, 248, 165, 126, 115, 102, 123, 50, 181, 188, 33, 57, 177, 205, 8, 82, 91, 6, 152, 161, 201, 19, 14, 249, 192, 185, 68, 240, 220, 134, 252, 21, 95, 82, 155, 204, 152, 215, 108, 107, 202, 19, 246, 48, 105, 164, 73, 163, 98, 249, 173, 189, 73, 21, 126, 90, 73, 77, 76, 97, 137, 53, 188, 196, 77, 58, 78, 94, 36, 46, 93, 55, 241, 177, 22, 16, 62, 201, 159, 109, 83, 161, 249, 123, 85, 88, 146, 124, 79, 233, 70, 127, 174, 239, 61, 224, 170, 226, 194, 195 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("0ec2dc1d-b153-42f5-ba15-07b50b9d35e6"), new DateTime(2022, 9, 23, 11, 54, 28, 399, DateTimeKind.Utc).AddTicks(3621), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("6408f79f-0813-4048-8843-a7a8d2f2ab7e"), new DateTime(2022, 9, 23, 11, 54, 28, 399, DateTimeKind.Utc).AddTicks(3619), 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Mentor_MentorId",
                table: "Intern",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
