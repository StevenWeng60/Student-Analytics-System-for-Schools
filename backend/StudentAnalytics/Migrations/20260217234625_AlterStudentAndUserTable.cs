using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAnalytics.Migrations
{
    /// <inheritdoc />
    public partial class AlterStudentAndUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_type",
                keyValue: null,
                column: "user_type",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_type",
                table: "users",
                type: "enum('teacher','admin','other')",
                nullable: false,
                defaultValueSql: "'other'",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "enum('teacher','admin','other')",
                oldNullable: true,
                oldDefaultValueSql: "'other'")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "last_name",
                keyValue: null,
                column: "last_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "students",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_type",
                table: "users",
                type: "enum('teacher','admin','other')",
                nullable: true,
                defaultValueSql: "'other'",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "enum('teacher','admin','other')",
                oldDefaultValueSql: "'other'")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "students",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
