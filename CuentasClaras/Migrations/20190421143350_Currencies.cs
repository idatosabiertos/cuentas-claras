using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class Currencies : Migration
    {
        private readonly int YEAR_2015 = 2015;
        private readonly int YEAR_2016 = 2016;
        private readonly int YEAR_2017 = 2017;
        private readonly int YEAR_2018 = 2018;

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //2015
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 8.9110, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 21.334, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 28.373, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 31.160, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 41.768, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 27.375, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.1120, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.0000, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.1390, YEAR_2015 });
            //2016
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 8.7380, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 22.733, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 30.541, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 34.440, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 40.821, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 30.136, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.4080, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.0000, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.0530, YEAR_2016 });
            //2017
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 8.9350, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 22.109, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 29.120, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 33.820, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 36.960, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 28.681, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.6280, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.0000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.1540, YEAR_2017 });
            //2018
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 8.5050, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 23.707, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 31.399, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 37.910, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 40.954, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 30.750, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.8970, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.0000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.3240, YEAR_2018 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
