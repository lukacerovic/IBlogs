using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBlogs.Migrations
{
    /// <inheritdoc />
    public partial class AddingProfileId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                schema: "Identity",
                table: "User",
                type: "uniqueidentifier",
                nullable: false
                );

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileId",
                schema: "Identity",
                table: "User");

            
        }
    }
}
