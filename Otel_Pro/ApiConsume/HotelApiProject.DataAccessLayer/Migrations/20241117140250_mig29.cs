using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApiProject.DataAccessLayer.Migrations
{
    public partial class mig29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Rooms_RoomId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Comments",
                newName: "roomId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RoomId",
                table: "Comments",
                newName: "IX_Comments_roomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_userId",
                table: "Comments",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Rooms_roomId",
                table: "Comments",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_userId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Rooms_roomId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Comments",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_roomId",
                table: "Comments",
                newName: "IX_Comments_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Rooms_RoomId",
                table: "Comments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
