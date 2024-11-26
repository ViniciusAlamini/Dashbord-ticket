using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDashboard.Migrations
{
    /// <inheritdoc />
    public partial class migratiosPrioridade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PRIORITY",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PRIORITY",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "Tickets");
        }
    }
}
