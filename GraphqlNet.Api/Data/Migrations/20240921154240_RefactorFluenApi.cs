using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphqlNet.Api.Migrations
{
    /// <inheritdoc />
    public partial class RefactorFluenApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishingHouseID",
                table: "PublishingHouses",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PublishingHouses",
                newName: "PublishingHouseID");
        }
    }
}
