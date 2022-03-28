using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateBaseAULA19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LOGSISTEMA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    LOG_JSONINFORMACAO = table.Column<string>(nullable: true),
                    LOG_TIPOLOG = table.Column<int>(nullable: false),
                    LOG_CONTROLLER = table.Column<string>(nullable: true),
                    LOG_ACTION = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOGSISTEMA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_LOGSISTEMA_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_LOGSISTEMA_UserId",
                table: "TB_LOGSISTEMA",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LOGSISTEMA");
        }
    }
}
