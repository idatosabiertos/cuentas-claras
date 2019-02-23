using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class TopSuppliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[TopSuppliers]
                     AS
                     BEGIN
                         SET NOCOUNT ON;
                         SELECT S.SupplierId, 
	                            S.Name, 
	                            SUM(R.TotalAmountUYU) as TotalAmount, 
	                            COUNT(*) as Quantity
                         FROM Releases as R
                         INNER JOIN Suppliers as S on S.SupplierId = R.SupplierId
                         GROUP BY S.SupplierId, S.Name
                         ORDER BY TotalAmount DESC;
                     END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
