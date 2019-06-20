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
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 9.110000000, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 21.33400121, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 28.37290324, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 31.16000000, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 41.76820364, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 27.70000000, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.627884000, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.000000000, YEAR_2015 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.400000000, YEAR_2015 });
            //2016
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 9.470000000, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 22.73290645, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 29.12038008, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 34.44000000, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 36.96011179, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 30.57000000, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.627884000, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.000000000, YEAR_2016 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.400000000, YEAR_2016 });
            //2017
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 9.360000000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 22.10889400, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 29.12038000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 33.82000000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 36.96000000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 29.18000000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.627884000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.000000000, YEAR_2017 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.400000000, YEAR_2017 });
            //2018
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "BRL", 9.060000000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CAD", 22.10889400, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "CHF", 29.12038000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "EUR", 38.96000000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "GBP", 36.96000000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "USD", 31.37000000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYI", 3.627884000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "UYU", 1.000000000, YEAR_2018 });
            migrationBuilder.InsertData("Currencies", new string[] { "CurrencyCode", "ConversionFactorUYU", "Year" }, new object[] { "ZAR", 2.400000000, YEAR_2018 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
