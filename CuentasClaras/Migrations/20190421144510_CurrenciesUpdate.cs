using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class CurrenciesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "BRL", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "BRL", 9.360000 });
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "CAD", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "CAD", 22.108894 });
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "CHF", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "CHF", 29.120380 });
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "EUR", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "EUR", 33.820000 });
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "GBP", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "GBP", 36.960000 });
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "USD", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "USD", 29.180000 });
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "UYI", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "UYI", 3.627884 });
            migrationBuilder.UpdateData("Currencies", "CurrencyCode", "UYU", new string[] { "CurrencyCode", "ConversionFactorUYU" }, new object[] { "UYU", 1.000000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
