using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TipoPersonajerevert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_TipoPersonaje_idTipoPersonaje",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_idTipoPersonaje",
                table: "Personaje");

            migrationBuilder.AddColumn<int>(
                name: "tipoid",
                table: "Personaje",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_tipoid",
                table: "Personaje",
                column: "tipoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_TipoPersonaje_tipoid",
                table: "Personaje",
                column: "tipoid",
                principalTable: "TipoPersonaje",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_TipoPersonaje_tipoid",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_tipoid",
                table: "Personaje");

            migrationBuilder.DropColumn(
                name: "tipoid",
                table: "Personaje");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_idTipoPersonaje",
                table: "Personaje",
                column: "idTipoPersonaje");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_TipoPersonaje_idTipoPersonaje",
                table: "Personaje",
                column: "idTipoPersonaje",
                principalTable: "TipoPersonaje",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
