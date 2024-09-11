using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserIdentityManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic]) VALUES (N'7e3be8df-f86d-4ede-8959-f4bf56726588', N'admin@string.com', N'ADMIN@STRING.COM', N'admin@string.com', N'ADMIN@STRING.COM', 0, N'AQAAAAIAAYagAAAAEK2JKitUO805yBQ3CgB+uLQxCPXFCj5JndxUHlgm4bneAaTYBglHv6DCQURsbQmwtw==', N'FPHELJKIJKRSRK4TU3QLDHP3XQZQJZ4K', N'203aaad4-5e7f-484d-a518-a86f637c5741', NULL, 0, 0, NULL, 1, 0, N'Steveo', NULL, NULL)\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id = '7e3be8df-f86d-4ede-8959-f4bf56726588' ");
        }
    }
}
