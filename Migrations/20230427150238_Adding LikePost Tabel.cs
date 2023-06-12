using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBlogs.Migrations
{
    /// <inheritdoc />
    public partial class AddingLikePostTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikePosts",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserWhoLiked = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikedPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerOfPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikePosts_User_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_ProfileId",
                schema: "Identity",
                table: "LikePosts",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikePosts",
                schema: "Identity");
        }
    }
}
