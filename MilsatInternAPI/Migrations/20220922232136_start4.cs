using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class start4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Mentor_MentorId1",
                table: "Intern");

            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Users_MentorId",
                table: "Intern");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor");

            migrationBuilder.DropIndex(
                name: "IX_Mentor_UserId",
                table: "Mentor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intern",
                table: "Intern");

            migrationBuilder.DropIndex(
                name: "IX_Intern_MentorId1",
                table: "Intern");

            migrationBuilder.DropIndex(
                name: "IX_Intern_UserId",
                table: "Intern");

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f80584c0-b27e-422b-8b5d-192a2895a567"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("747cc885-aaea-43db-85aa-c47168d05bdb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d09230de-e3a0-49a8-8893-fe7906d895fc"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mentor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Intern");

            migrationBuilder.DropColumn(
                name: "MentorId1",
                table: "Intern");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intern",
                table: "Intern",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("7ce664b2-9402-4ea4-9d43-0a8bef117cce"), "", 1, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 222, 46, 77, 46, 251, 203, 218, 143, 207, 201, 28, 159, 65, 66, 1, 221, 53, 217, 144, 199, 200, 189, 7, 207, 152, 213, 214, 168, 174, 59, 226, 174, 129, 75, 250, 220, 40, 250, 92, 111, 188, 198, 97, 123, 75, 53, 80, 208, 25, 200, 252, 40, 71, 184, 187, 112, 36, 32, 190, 202, 208, 128, 225, 130 }, new byte[] { 163, 16, 208, 107, 241, 29, 224, 114, 59, 223, 7, 48, 51, 215, 5, 163, 249, 222, 68, 60, 43, 41, 131, 198, 249, 190, 178, 143, 235, 117, 136, 79, 216, 120, 28, 85, 141, 237, 27, 179, 227, 119, 129, 79, 111, 182, 14, 96, 161, 76, 118, 94, 191, 134, 138, 118, 142, 119, 154, 89, 238, 134, 169, 132, 29, 9, 232, 118, 123, 22, 222, 26, 66, 243, 127, 95, 100, 146, 124, 122, 160, 234, 123, 213, 115, 246, 208, 243, 113, 204, 208, 223, 87, 101, 198, 12, 89, 26, 235, 241, 130, 9, 177, 9, 182, 184, 204, 56, 143, 214, 15, 63, 254, 217, 30, 50, 248, 205, 73, 133, 197, 172, 61, 123, 32, 154, 162, 17 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("f006954e-ec99-4b2e-ae63-bd4ddab5dc8e"), "", 6, "admin@milsat.com", "Admin", 0, new byte[] { 71, 12, 190, 96, 66, 202, 134, 44, 238, 253, 97, 195, 55, 199, 137, 18, 236, 142, 124, 241, 4, 219, 189, 112, 136, 41, 184, 49, 75, 247, 215, 125, 133, 11, 252, 52, 88, 216, 31, 193, 49, 52, 86, 72, 153, 186, 71, 90, 31, 198, 82, 217, 87, 236, 215, 28, 236, 68, 18, 115, 11, 120, 255, 59 }, new byte[] { 133, 4, 161, 135, 200, 146, 224, 218, 48, 65, 227, 108, 156, 189, 23, 94, 157, 220, 87, 32, 107, 162, 118, 104, 194, 143, 38, 177, 57, 97, 222, 65, 206, 120, 195, 43, 183, 103, 231, 68, 243, 143, 220, 18, 114, 161, 26, 163, 191, 155, 162, 176, 53, 16, 59, 135, 119, 144, 36, 139, 63, 0, 223, 97, 38, 65, 162, 172, 225, 50, 87, 246, 166, 137, 149, 153, 200, 195, 53, 41, 180, 136, 5, 119, 78, 242, 86, 242, 119, 167, 151, 249, 212, 37, 95, 215, 105, 120, 187, 56, 63, 114, 109, 159, 177, 72, 99, 33, 15, 203, 207, 68, 127, 150, 188, 103, 19, 12, 21, 155, 239, 90, 208, 193, 242, 34, 5, 208 }, "home", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[] { new Guid("fdab5574-06c1-4d07-9e5f-c978dc422786"), "", 1, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 145, 234, 254, 246, 243, 16, 147, 184, 43, 160, 208, 115, 250, 199, 128, 51, 226, 167, 167, 9, 171, 27, 163, 58, 56, 36, 184, 180, 112, 101, 130, 83, 40, 18, 23, 90, 92, 123, 109, 120, 149, 39, 193, 81, 172, 196, 30, 145, 22, 130, 40, 4, 29, 223, 103, 101, 246, 170, 131, 39, 78, 116, 150, 99 }, new byte[] { 138, 88, 87, 60, 109, 127, 6, 110, 115, 195, 216, 74, 239, 187, 21, 229, 247, 234, 222, 169, 249, 215, 209, 31, 15, 254, 246, 94, 70, 194, 117, 173, 201, 95, 172, 89, 100, 87, 108, 145, 70, 240, 172, 141, 66, 151, 215, 210, 1, 184, 102, 89, 57, 31, 143, 60, 251, 102, 179, 255, 101, 161, 149, 8, 158, 8, 15, 12, 157, 163, 167, 26, 64, 47, 110, 92, 57, 150, 231, 161, 68, 16, 161, 208, 16, 173, 86, 198, 126, 208, 16, 188, 147, 216, 216, 69, 118, 57, 115, 106, 87, 238, 122, 42, 197, 214, 222, 118, 145, 142, 68, 185, 44, 71, 190, 188, 176, 242, 54, 40, 110, 60, 122, 155, 85, 78, 60, 178 }, "string", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("7ce664b2-9402-4ea4-9d43-0a8bef117cce"), new DateTime(2022, 9, 22, 23, 21, 36, 285, DateTimeKind.Utc).AddTicks(759), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("fdab5574-06c1-4d07-9e5f-c978dc422786"), new DateTime(2022, 9, 22, 23, 21, 36, 285, DateTimeKind.Utc).AddTicks(757), 0 });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intern",
                table: "Intern");

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("7ce664b2-9402-4ea4-9d43-0a8bef117cce"));

            migrationBuilder.DeleteData(
                table: "Mentor",
                keyColumn: "UserId",
                keyValue: new Guid("fdab5574-06c1-4d07-9e5f-c978dc422786"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f006954e-ec99-4b2e-ae63-bd4ddab5dc8e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7ce664b2-9402-4ea4-9d43-0a8bef117cce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("fdab5574-06c1-4d07-9e5f-c978dc422786"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Mentor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Intern",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MentorId1",
                table: "Intern",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intern",
                table: "Intern",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "Id", "CreatedOn", "Status", "UserId" },
                values: new object[] { 1, new DateTime(2022, 9, 22, 23, 16, 39, 57, DateTimeKind.Utc).AddTicks(5503), 0, new Guid("747cc885-aaea-43db-85aa-c47168d05bdb") });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "Id", "CreatedOn", "Status", "UserId" },
                values: new object[] { 2, new DateTime(2022, 9, 22, 23, 16, 39, 57, DateTimeKind.Utc).AddTicks(5505), 0, new Guid("d09230de-e3a0-49a8-8893-fe7906d895fc") });

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_UserId",
                table: "Mentor",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intern_MentorId1",
                table: "Intern",
                column: "MentorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_UserId",
                table: "Intern",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Mentor_MentorId1",
                table: "Intern",
                column: "MentorId1",
                principalTable: "Mentor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Users_MentorId",
                table: "Intern",
                column: "MentorId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
