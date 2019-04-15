using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class TopItemClassification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[TopItemClassification]
                     AS
                     BEGIN
                        SET NOCOUNT ON;
                        
                        SELECT
                        C.ReleaseItemClassificationId, C.Description, T.TotalAmount 
                        FROM 
                        (SELECT
	                        R.ReleaseItemClassificationId as ReleaseItemClassificationId,
	                        SUM(R.UnitValueAmount * Quantity) as TotalAmount
                        FROM ReleaseItems as R
                        GROUP BY R.ReleaseItemClassificationId, R.UnitName) as T
                        INNER JOIN ReleaseItemClassifications as C on 
		                            C.ReleaseItemClassificationId = T.ReleaseItemClassificationId
                        ORDER BY T.TotalAmount DESC

                     END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
