using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiPerson.Migrations
{
    /// <inheritdoc />
    public partial class newmodifcationfinalizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Persons",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Persons",
                newName: "PasswordHash");
        }
    }
}
