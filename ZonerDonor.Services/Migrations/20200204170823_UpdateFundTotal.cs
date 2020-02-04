using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZonerDonor.Services.Migrations
{
    public partial class UpdateFundTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "DonationDate", "DonorId", "FundraiserId" },
                values: new object[] { new Guid("b605f1cb-dcf9-4087-a0b2-6c38475bda8e"), 40m, new DateTimeOffset(new DateTime(2020, 2, 4, 12, 8, 22, 701, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, -5, 0, 0, 0)), new Guid("1c2c642c-3a9c-4053-b5ed-07e9c44f109d"), new Guid("bd5f9fb5-bd76-446f-8e06-d1f4cc24dfc1") });

            migrationBuilder.InsertData(
                table: "Donors",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { new Guid("1c2c642c-3a9c-4053-b5ed-07e9c44f109d"), new DateTimeOffset(new DateTime(2020, 1, 5, 12, 8, 22, 697, DateTimeKind.Unspecified).AddTicks(4186), new TimeSpan(0, -5, 0, 0, 0)), "Marcus" });

            migrationBuilder.InsertData(
                table: "Fundraisers",
                columns: new[] { "Id", "Amount", "CreatedDate", "CurrentTotal", "Name" },
                values: new object[] { new Guid("bd5f9fb5-bd76-446f-8e06-d1f4cc24dfc1"), 10000m, new DateTimeOffset(new DateTime(2020, 2, 1, 12, 8, 22, 701, DateTimeKind.Unspecified).AddTicks(4263), new TimeSpan(0, -5, 0, 0, 0)), 0m, "Pauls Extension" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: new Guid("b605f1cb-dcf9-4087-a0b2-6c38475bda8e"));

            migrationBuilder.DeleteData(
                table: "Donors",
                keyColumn: "Id",
                keyValue: new Guid("1c2c642c-3a9c-4053-b5ed-07e9c44f109d"));

            migrationBuilder.DeleteData(
                table: "Fundraisers",
                keyColumn: "Id",
                keyValue: new Guid("bd5f9fb5-bd76-446f-8e06-d1f4cc24dfc1"));

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
    }
}
