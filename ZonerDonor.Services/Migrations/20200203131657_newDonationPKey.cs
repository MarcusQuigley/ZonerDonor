using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZonerDonor.Services.Migrations
{
    public partial class newDonationPKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

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

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentTotal",
                table: "Fundraisers",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Fundraisers",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Donations",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Donations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "DonationDate", "DonorId", "FundraiserId" },
                values: new object[] { new Guid("c35a51ef-8073-418e-ade0-9a91b2464e3a"), 40m, new DateTimeOffset(new DateTime(2020, 2, 3, 8, 16, 56, 664, DateTimeKind.Unspecified).AddTicks(2210), new TimeSpan(0, -5, 0, 0, 0)), new Guid("6a755722-5a2b-4e43-87b2-9f0295ee916f"), new Guid("ca696b1a-0110-4da3-9c1a-96add5373d98") });

            migrationBuilder.InsertData(
                table: "Donors",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { new Guid("6a755722-5a2b-4e43-87b2-9f0295ee916f"), new DateTimeOffset(new DateTime(2020, 1, 4, 8, 16, 56, 659, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, -5, 0, 0, 0)), "Marcus" });

            migrationBuilder.InsertData(
                table: "Fundraisers",
                columns: new[] { "Id", "Amount", "CreatedDate", "CurrentTotal", "Name" },
                values: new object[] { new Guid("ca696b1a-0110-4da3-9c1a-96add5373d98"), 10000m, new DateTimeOffset(new DateTime(2020, 1, 31, 8, 16, 56, 663, DateTimeKind.Unspecified).AddTicks(8699), new TimeSpan(0, -5, 0, 0, 0)), 0m, "Pauls Extension" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: new Guid("c35a51ef-8073-418e-ade0-9a91b2464e3a"));

            migrationBuilder.DeleteData(
                table: "Donors",
                keyColumn: "Id",
                keyValue: new Guid("6a755722-5a2b-4e43-87b2-9f0295ee916f"));

            migrationBuilder.DeleteData(
                table: "Fundraisers",
                keyColumn: "Id",
                keyValue: new Guid("ca696b1a-0110-4da3-9c1a-96add5373d98"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Donations");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentTotal",
                table: "Fundraisers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Fundraisers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Donations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                columns: new[] { "FundraiserId", "DonorId" });

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
    }
}
