using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleService.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsScheduledColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsScheduled",
                table: "Meetings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsScheduled",
                table: "Meetings");
        }
    }
}
