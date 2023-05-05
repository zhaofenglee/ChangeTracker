using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JS.Abp.ChangeTracker.Blazor.Server.Host.Migrations
{
    /// <inheritdoc />
    public partial class updateabp721 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangeTrackerChangeLogs",
                table: "ChangeTrackerChangeLogs");

            migrationBuilder.RenameTable(
                name: "ChangeTrackerChangeLogs",
                newName: "AbpChangeLogs");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastPasswordChangeTime",
                table: "AbpUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShouldChangePasswordOnNextLogin",
                table: "AbpUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpChangeLogs",
                table: "AbpChangeLogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AbpUserDelegations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserDelegations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpUserDelegations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpChangeLogs",
                table: "AbpChangeLogs");

            migrationBuilder.DropColumn(
                name: "LastPasswordChangeTime",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ShouldChangePasswordOnNextLogin",
                table: "AbpUsers");

            migrationBuilder.RenameTable(
                name: "AbpChangeLogs",
                newName: "ChangeTrackerChangeLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangeTrackerChangeLogs",
                table: "ChangeTrackerChangeLogs",
                column: "Id");
        }
    }
}
