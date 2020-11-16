using Microsoft.EntityFrameworkCore.Migrations;

namespace ScreamAPI.Migrations
{
    public partial class Adicionadoexclusãológica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ex_imagem",
                table: "Tb_Imagens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ex_imagem",
                table: "Tb_Imagens");
        }
    }
}
