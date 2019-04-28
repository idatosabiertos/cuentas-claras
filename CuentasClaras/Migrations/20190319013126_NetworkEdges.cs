using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class NetworkEdges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[NetworkEdges](@datasource as varchar(4))
                     AS
                     BEGIN
                         SET NOCOUNT ON;
                         SELECT DISTINCT B.BuyerId, S.SupplierId 
						 FROM Releases as R
                         JOIN Buyers as B ON R.BuyerId = B.BuyerId
                         JOIN Suppliers as S ON R.SupplierId = S.SupplierId
						 WHERE R.DataSource = @datasource
                         ORDER BY BuyerId, SupplierId
                     END";

            migrationBuilder.Sql(sp);
       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
