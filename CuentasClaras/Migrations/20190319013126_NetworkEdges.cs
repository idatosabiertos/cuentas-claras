using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class NetworkEdges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[NetworkEdges]
                     AS
                     BEGIN
                         SET NOCOUNT ON;
                         SELECT DISTINCT B.BuyerId, S.SupplierId FROM [cuentasclaras].[dbo].[Releases] as R
                         JOIN[cuentasclaras].[dbo].[Buyers] as B ON R.BuyerId = B.BuyerId
                         JOIN[cuentasclaras].[dbo].[Suppliers] as S ON R.SupplierId = S.SupplierId
                         ORDER BY BuyerId, SupplierId
                     END";

            migrationBuilder.Sql(sp);
       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
