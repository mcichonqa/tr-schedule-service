using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleService.Entity.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHasSubscriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasSubscription",
                table: "Meetings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasSubscription",
                table: "Meetings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
