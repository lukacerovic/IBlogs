using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBlogs.Migrations
{
    /// <inheritdoc />
    public partial class AddingCommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentPost",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfComment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPost_User_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_ProfileId",
                schema: "Identity",
                table: "CommentPost",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentPost",
                schema: "Identity");
        }
    }
}
