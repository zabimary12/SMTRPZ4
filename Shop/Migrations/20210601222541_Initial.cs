using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameCategory = table.Column<string>(nullable: true),
                    descCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "knife",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameKnife = table.Column<string>(nullable: true),
                    shortDisc = table.Column<string>(nullable: true),
                    longDisc = table.Column<string>(nullable: true),
                    imgKnife = table.Column<string>(nullable: true),
                    steal = table.Column<string>(nullable: true),
                    priceKnife = table.Column<int>(nullable: false),
                    isFavorite = table.Column<bool>(nullable: false),
                    available = table.Column<bool>(nullable: false),
                    categoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_knife", x => x.id);
                    table.ForeignKey(
                        name: "FK_knife_category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_knife_categoryID",
                table: "knife",
                column: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "knife");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
