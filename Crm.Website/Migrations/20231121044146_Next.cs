using Microsoft.EntityFrameworkCore.Migrations;


namespace Crm.Website.Migrations
{
    /// <inheritdoc />
    public partial class Next : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Students",
                newName: "MiddeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddeName",
                table: "Students",
                newName: "MiddleName");
        }
    }

}
