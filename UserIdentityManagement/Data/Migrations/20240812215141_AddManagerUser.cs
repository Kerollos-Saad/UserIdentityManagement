using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserIdentityManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManagerUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic]) VALUES (N'1484a57f-acd8-4547-ba25-b7f3f6434669', N'manager@string.com', N'MANAGER@STRING.COM', N'manager@string.com', N'MANAGER@STRING.COM', 0, N'AQAAAAIAAYagAAAAECt2M2ISlQTHncm7hOBMe5xFUsoRC8c/rWtaaBIlRlUsbBSutojfEtGYsJirk4vc2g==', N'EAQ2O4LPD6BLB2OH7AVFSB3CGDV3LDTH', N'de44a379-a6da-4d45-bdd8-e39fb6221e53', NULL, 0, 0, NULL, 1, 0, N'Arnoldo', NULL, NULL)\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id = '1484a57f-acd8-4547-ba25-b7f3f6434669'");
        }
    }
}