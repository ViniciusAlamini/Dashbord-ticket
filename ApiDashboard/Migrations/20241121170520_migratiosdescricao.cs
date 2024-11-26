using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDashboard.Migrations
{
    /// <inheritdoc />
    public partial class migratiosdescricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                table: "Tickets");
        }
    }
}
