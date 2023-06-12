using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBlogs.Migrations
{
    /// <inheritdoc />
    public partial class CommentsUserProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PostsId",
                schema: "Identity",
                table: "CommentPost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfileImage",
                schema: "Identity",
                table: "CommentPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_PostsId",
                schema: "Identity",
                table: "CommentPost",
                column: "PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPost_BlogPosts_PostsId",
                schema: "Identity",
                table: "CommentPost",
                column: "PostsId",
                principalSchema: "Identity",
                principalTable: "BlogPosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPost_BlogPosts_PostsId",
                schema: "Identity",
                table: "CommentPost");

            migrationBuilder.DropIndex(
                name: "IX_CommentPost_PostsId",
                schema: "Identity",
                table: "CommentPost");

            migrationBuilder.DropColumn(
                name: "PostsId",
                schema: "Identity",
                table: "CommentPost");

            migrationBuilder.DropColumn(
                name: "UserProfileImage",
                schema: "Identity",
                table: "CommentPost");
        }
    }
}
