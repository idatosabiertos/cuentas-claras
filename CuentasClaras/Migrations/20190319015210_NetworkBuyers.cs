using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class NetworkBuyers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[NetworkBuyers](@datasource as varchar(4))
                     AS
                     BEGIN
                         SET NOCOUNT ON;
                         SELECT S.BuyerId, S.Name, S.Type, SUM(R.TotalAmountUYU) as TotalAmountUYU 
						 FROM Releases as R
                         JOIN Buyers as S ON R.BuyerId = S.BuyerId
						 WHERE R.DataSource = @datasource
                         GROUP BY S.BuyerId, S.Name, S.Type
                         ORDER BY TotalAmountUYU
                     END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
