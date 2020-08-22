using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.DLL.Migrations
{
    public partial class spGetAllEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE [dbo].[spGetAllEmployees]  
AS
BEGIN
 SELECT* FROM[dbo].[Employees]
            END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE [dbo].[spGetAllEmployees] ";
            migrationBuilder.Sql(procedure);
        }
    }
}
