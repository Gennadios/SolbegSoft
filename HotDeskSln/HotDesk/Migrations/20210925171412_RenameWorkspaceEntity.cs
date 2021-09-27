using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDesk.Migrations
{
    public partial class RenameWorkspaceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Workspaces_WorkplaceId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workspaces",
                table: "Workspaces");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Workspaces");

            migrationBuilder.RenameTable(
                name: "Workspaces",
                newName: "Workplaces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Workplaces_WorkplaceId",
                table: "Reservations",
                column: "WorkplaceId",
                principalTable: "Workplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Workplaces_WorkplaceId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces");

            migrationBuilder.RenameTable(
                name: "Workplaces",
                newName: "Workspaces");

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Workspaces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workspaces",
                table: "Workspaces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Workspaces_WorkplaceId",
                table: "Reservations",
                column: "WorkplaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
