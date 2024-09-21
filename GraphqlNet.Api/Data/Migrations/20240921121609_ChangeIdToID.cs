using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphqlNet.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdToID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookReviews_BookID",
                table: "BookReviews");

            migrationBuilder.DropColumn(
                name: "BookReviewId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookID",
                table: "BookReviews",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookReviews_BookID",
                table: "BookReviews");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddColumn<Guid>(
                name: "BookReviewId",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookID",
                table: "BookReviews",
                column: "BookID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
