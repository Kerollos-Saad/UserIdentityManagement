using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserIdentityManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssignManagerUserToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO [security].[UserRoles] (UserId, RoleId) SELECT '1484a57f-acd8-4547-ba25-b7f3f6434669', Id FROM [security].[Roles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId = '1484a57f-acd8-4547-ba25-b7f3f6434669'");
        }
    }
}
