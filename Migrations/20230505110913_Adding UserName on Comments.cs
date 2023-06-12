using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBlogs.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserNameonComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserProfileImage",
                schema: "Identity",
                table: "CommentPost",
                newName: "UserProfileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserProfileName",
                schema: "Identity",
                table: "CommentPost",
                newName: "UserProfileImage");
        }
    }
}
