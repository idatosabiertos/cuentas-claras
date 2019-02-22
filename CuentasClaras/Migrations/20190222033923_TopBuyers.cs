using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class TopBuyers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[TopBuyers]
                     AS
                     BEGIN
                         SET NOCOUNT ON;
                         SELECT B.BuyerId, 
	                            B.Name, 
	                            SUM(R.TotalAmount) as TotalAmount, 
	                            COUNT(*) as Quantity
                         FROM Releases as R
                         INNER JOIN Buyers as B on B.BuyerId = R.BuyerId
                         GROUP BY B.BuyerId, B.Name
                         ORDER BY TotalAmount DESC
                     END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
