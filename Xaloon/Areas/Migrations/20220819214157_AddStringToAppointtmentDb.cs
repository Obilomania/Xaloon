using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xaloon.Data.Migrations
{
    public partial class AddStringToAppointtmentDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_BookerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Days_DayId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Times_TimeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Titles_TitleId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BookerId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BookerId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TimeId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Days_DayId",
                table: "Appointments",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Times_TimeId",
                table: "Appointments",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Titles_TitleId",
                table: "Appointments",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Days_DayId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Times_TimeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Titles_TitleId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TimeId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BookerId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BookerId",
                table: "Appointments",
                column: "BookerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_BookerId",
                table: "Appointments",
                column: "BookerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Days_DayId",
                table: "Appointments",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Times_TimeId",
                table: "Appointments",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Titles_TitleId",
                table: "Appointments",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
