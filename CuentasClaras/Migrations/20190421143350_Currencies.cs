using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class Currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "BRL", 9.360000 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "CAD", 22.108894 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "CHF", 29.120380 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "EUR", 33.820000 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "GBP", 36.960000 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "USD", 29.180000 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "UYI", 3.627884 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "UYU", 1.000000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
