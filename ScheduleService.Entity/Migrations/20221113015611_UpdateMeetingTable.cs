using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleService.Entity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMeetingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConversationType",
                table: "Meetings",
                newName: "MeetingTopic");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Meetings",
                newName: "ClientId");

            migrationBuilder.AddColumn<bool>(
                name: "HasSubscription",
                table: "Meetings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasSubscription",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "MeetingTopic",
                table: "Meetings",
                newName: "ConversationType");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Meetings",
                newName: "AuthorId");
        }
    }
}
