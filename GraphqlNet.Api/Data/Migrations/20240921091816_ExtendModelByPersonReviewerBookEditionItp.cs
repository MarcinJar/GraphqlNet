using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphqlNet.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExtendModelByPersonReviewerBookEditionItp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "PersonID");

            migrationBuilder.AddColumn<Guid>(
                name: "BookReviewId",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PublishingHouses",
                columns: table => new
                {
                    PublishingHouseID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouses", x => x.PublishingHouseID);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviewers_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookEditions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookID = table.Column<Guid>(type: "TEXT", nullable: false),
                    EditionNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Format = table.Column<int>(type: "INTEGER", nullable: false),
                    PublisherID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEditions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookEditions_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookEditions_PublishingHouses_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "PublishingHouses",
                        principalColumn: "PublishingHouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReviews",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReviewerID = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    ReviewText = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReviews_Reviewers_ReviewerID",
                        column: x => x.ReviewerID,
                        principalTable: "Reviewers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PersonID",
                table: "Authors",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_BookID",
                table: "BookEditions",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_PublisherID",
                table: "BookEditions",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookID",
                table: "BookReviews",
                column: "BookID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_ReviewerID",
                table: "BookReviews",
                column: "ReviewerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewers_PersonID",
                table: "Reviewers",
                column: "PersonID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Persons_PersonID",
                table: "Authors",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Persons_PersonID",
                table: "Authors");

            migrationBuilder.DropTable(
                name: "BookEditions");

            migrationBuilder.DropTable(
                name: "BookReviews");

            migrationBuilder.DropTable(
                name: "PublishingHouses");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Authors_PersonID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BookReviewId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Authors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Authors",
                newName: "Name");
        }
    }
}
