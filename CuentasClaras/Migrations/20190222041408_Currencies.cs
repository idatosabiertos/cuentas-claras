using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class Currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Currencies", 
                                        new[] { "CurrencyCode", "ConversionFactorUYU" },
                                        new object[] { "UYU" , 0.03});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
