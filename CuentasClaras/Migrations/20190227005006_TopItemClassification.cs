using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class TopItemClassification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[TopItemClassification](@datasource as varchar(4))
                     AS
                     BEGIN
                        SET NOCOUNT ON;
                        
                        SELECT
                        C.ReleaseItemClassificationId, C.Description, T.TotalAmount 
                        FROM 
                        (SELECT
	                        R.ReleaseItemClassificationId as ReleaseItemClassificationId,
	                        SUM(R.UnitValueAmountUYU * Quantity) as TotalAmount
                        FROM ReleaseItems as R
						INNER JOIN Releases as RR on RR.ReleaseId = R.ReleaseId
						WHERE RR.DataSource = @datasource
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
