using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.MinimalApi.Contexts.Migrations
{
    public partial class SeedDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "Pages", "Price" },
                values: new object[] { new Guid("277e4596-d86b-4833-81d4-beef245fb637"), "JAVA", 620, 23.0 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "Pages", "Price" },
                values: new object[] { new Guid("53e5d3e2-3301-4875-af1d-2193dd3879fc"), "C# In Nutshell", 900, 35.0 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "Pages", "Price" },
                values: new object[] { new Guid("bce11a1b-daec-47ad-9163-ef810a789ba8"), "How to make Hawawshi?", 66, 8.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("277e4596-d86b-4833-81d4-beef245fb637"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("53e5d3e2-3301-4875-af1d-2193dd3879fc"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("bce11a1b-daec-47ad-9163-ef810a789ba8"));
        }
    }
}
