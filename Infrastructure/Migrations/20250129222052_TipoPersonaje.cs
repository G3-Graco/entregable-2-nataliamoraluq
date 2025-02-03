using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TipoPersonaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idTipoPersonaje",
                table: "Personaje",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoPersonaje",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonaje", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_TipoPersonaje_idTipoPersonaje",
                table: "Personaje");

            migrationBuilder.DropTable(
                name: "TipoPersonaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_idTipoPersonaje",
                table: "Personaje");

            migrationBuilder.DropColumn(
                name: "idTipoPersonaje",
                table: "Personaje");
        }
    }
}
