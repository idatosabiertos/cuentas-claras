using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class OrganisationIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganisationIndexes",
                columns: table => new
                {
                    OrganisationIndexId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<string>(nullable: true),
                    OrganisationId = table.Column<string>(nullable: true),
                    OrganistationShortName = table.Column<string>(nullable: true),
                    OrganisationName = table.Column<string>(nullable: true),
                    ConectionByAmount = table.Column<string>(nullable: true),
                    SanctionedCompanies = table.Column<string>(nullable: true),
                    Process = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompletedInfo = table.Column<string>(nullable: true),
                    ConcentrationOfSuppliers = table.Column<string>(nullable: true),
                    AccumulationOfSuppliersByOrganisation = table.Column<string>(nullable: true),
                    QuantityOfPurchasesByException = table.Column<string>(nullable: true),
                    PerformanceIndex = table.Column<string>(nullable: true),
                    QuantityOfPurchases = table.Column<string>(nullable: true),
                    BuyerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationIndexes", x => x.OrganisationIndexId);
                    table.ForeignKey(
                        name: "FK_OrganisationIndexes_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationIndexes_BuyerId",
                table: "OrganisationIndexes",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationIndexes");

           
        }
    }
}
