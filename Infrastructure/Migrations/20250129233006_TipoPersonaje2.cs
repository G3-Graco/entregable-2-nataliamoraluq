using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TipoPersonaje2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_TipoPersonaje_tipoid",
                table: "Personaje");

            migrationBuilder.DropColumn(
                name: "idTipoPersonaje",
                table: "Personaje");

            migrationBuilder.RenameColumn(
                name: "tipoid",
                table: "Personaje",
                newName: "tipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Personaje_tipoid",
                table: "Personaje",
                newName: "IX_Personaje_tipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_TipoPersonaje_tipoId",
                table: "Personaje",
                column: "tipoId",
                principalTable: "TipoPersonaje",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_TipoPersonaje_tipoId",
                table: "Personaje");

            migrationBuilder.RenameColumn(
                name: "tipoId",
                table: "Personaje",
                newName: "tipoid");

            migrationBuilder.RenameIndex(
                name: "IX_Personaje_tipoId",
                table: "Personaje",
                newName: "IX_Personaje_tipoid");

            migrationBuilder.AddColumn<int>(
                name: "idTipoPersonaje",
                table: "Personaje",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_TipoPersonaje_tipoid",
                table: "Personaje",
                column: "tipoid",
                principalTable: "TipoPersonaje",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
