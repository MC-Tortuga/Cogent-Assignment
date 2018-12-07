using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cogent.Migrations
{
    public partial class Call_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Call",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   CallNumber = table.Column<string>(nullable: true),
                   Description = table.Column<string>(nullable: true),
                   UserId = table.Column<long>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Call", x => x.Id);
                   table.ForeignKey(name: "FK_Call_AbpUsers_UserId",
                       column: x => x.UserId,
                       principalTable: "AbpUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict
                       );

               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Call");
        }
    }
}
