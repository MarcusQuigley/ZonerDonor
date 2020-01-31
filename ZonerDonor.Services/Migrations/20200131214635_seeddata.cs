using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZonerDonor.Services.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "FundraiserId", "DonorId", "Amount", "DonationDate" },
                values: new object[] { new Guid("77200551-cd4c-42ea-87e3-c9e87944fa1a"), new Guid("e5211cdb-ba2e-4bf6-878a-6cf5fa4816af"), 40m, new DateTimeOffset(new DateTime(2020, 1, 31, 16, 46, 35, 246, DateTimeKind.Unspecified).AddTicks(4785), new TimeSpan(0, -5, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Donors",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { new Guid("e5211cdb-ba2e-4bf6-878a-6cf5fa4816af"), new DateTimeOffset(new DateTime(2020, 1, 1, 16, 46, 35, 237, DateTimeKind.Unspecified).AddTicks(9924), new TimeSpan(0, -5, 0, 0, 0)), "Marcus" });

            migrationBuilder.InsertData(
                table: "Fundraisers",
                columns: new[] { "Id", "Amount", "CreatedDate", "CurrentTotal", "Name" },
                values: new object[] { new Guid("77200551-cd4c-42ea-87e3-c9e87944fa1a"), 10000m, new DateTimeOffset(new DateTime(2020, 1, 28, 16, 46, 35, 245, DateTimeKind.Unspecified).AddTicks(8730), new TimeSpan(0, -5, 0, 0, 0)), 0m, "Pauls Extension" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumns: new[] { "FundraiserId", "DonorId" },
                keyValues: new object[] { new Guid("77200551-cd4c-42ea-87e3-c9e87944fa1a"), new Guid("e5211cdb-ba2e-4bf6-878a-6cf5fa4816af") });

            migrationBuilder.DeleteData(
                table: "Donors",
                keyColumn: "Id",
                keyValue: new Guid("e5211cdb-ba2e-4bf6-878a-6cf5fa4816af"));

            migrationBuilder.DeleteData(
                table: "Fundraisers",
                keyColumn: "Id",
                keyValue: new Guid("77200551-cd4c-42ea-87e3-c9e87944fa1a"));
        }
    }
}
