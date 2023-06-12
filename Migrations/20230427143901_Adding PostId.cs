using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBlogs.Migrations
{
    /// <inheritdoc />
    public partial class AddingPostId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                schema: "Identity",
                table: "BlogPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                schema: "Identity",
                table: "BlogPosts");
        }
    }
}
