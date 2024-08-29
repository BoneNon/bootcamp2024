using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addseedidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28d65a5b-a7db-4850-b380-83591f7d7531", "28d65a5b-a7db-4850-b380-83591f7d7531", "Reader", "READER" },
                    { "9740f16c-24a1-4224-a7be-1bb00b7c6892", "9740f16c-24a1-4224-a7be-1bb00b7c6892", "Writer", "WRITER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "edc267ec-d43c-4e3b-8108-a1a1f819906d", 0, "7f291a3b-b6b1-4638-a560-f04c94a6eb2b", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBA4GtPJaCgawvejiIQAILw5n57l6y+p3RNbE+fCs49u+ZKQXdfaeG1prEAYKgu5eQ==", null, false, "68fe1c66-ac4f-4f6d-8b11-4bdb90c8a424", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "28d65a5b-a7db-4850-b380-83591f7d7531", "edc267ec-d43c-4e3b-8108-a1a1f819906d" },
                    { "9740f16c-24a1-4224-a7be-1bb00b7c6892", "edc267ec-d43c-4e3b-8108-a1a1f819906d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28d65a5b-a7db-4850-b380-83591f7d7531", "edc267ec-d43c-4e3b-8108-a1a1f819906d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9740f16c-24a1-4224-a7be-1bb00b7c6892", "edc267ec-d43c-4e3b-8108-a1a1f819906d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d65a5b-a7db-4850-b380-83591f7d7531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9740f16c-24a1-4224-a7be-1bb00b7c6892");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc267ec-d43c-4e3b-8108-a1a1f819906d");
        }
    }
}
