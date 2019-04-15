using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class NetworkSuppliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[NetworkSuppliers]
                     AS
                     BEGIN
                         SET NOCOUNT ON;
                         SELECT S.SupplierId, S.Name, SUM(R.TotalAmountUYU) as TotalAmountUYU FROM
                         Releases as R
                         JOIN Suppliers as S ON R.SupplierId = S.SupplierId
                         GROUP BY S.SupplierId, S.Name
                         ORDER BY TotalAmountUYU
                     END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
