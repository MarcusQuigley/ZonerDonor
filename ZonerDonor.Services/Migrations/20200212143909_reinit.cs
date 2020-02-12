using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZonerDonor.Services.Migrations
{
    public partial class reinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Donors",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { new Guid("a7def224-0b4a-43e6-874f-5ce4bb770b4a"), new DateTimeOffset(new DateTime(2020, 1, 13, 9, 39, 9, 573, DateTimeKind.Unspecified).AddTicks(3670), new TimeSpan(0, -5, 0, 0, 0)), "Marcus" });

            migrationBuilder.InsertData(
                table: "Fundraisers",
                columns: new[] { "Id", "Amount", "CreatedDate", "CurrentTotal", "Name" },
                values: new object[] { new Guid("4910d7d6-1fae-4895-8b50-eba56a64888d"), 10000m, new DateTimeOffset(new DateTime(2020, 2, 9, 9, 39, 9, 578, DateTimeKind.Unspecified).AddTicks(9687), new TimeSpan(0, -5, 0, 0, 0)), 0m, "Pauls Extension" });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "DonationDate", "DonorId", "FundraiserId" },
                values: new object[] { new Guid("c33b97c2-68f9-493a-909f-efc60d0b88dd"), 40m, new DateTimeOffset(new DateTime(2020, 2, 12, 9, 39, 9, 579, DateTimeKind.Unspecified).AddTicks(3161), new TimeSpan(0, -5, 0, 0, 0)), new Guid("a7def224-0b4a-43e6-874f-5ce4bb770b4a"), new Guid("4910d7d6-1fae-4895-8b50-eba56a64888d") });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_DonorId",
                table: "Donations");

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: new Guid("c33b97c2-68f9-493a-909f-efc60d0b88dd"));

            migrationBuilder.DeleteData(
                table: "Fundraisers",
                keyColumn: "Id",
                keyValue: new Guid("4910d7d6-1fae-4895-8b50-eba56a64888d"));

            migrationBuilder.DeleteData(
                table: "Donors",
                keyColumn: "Id",
                keyValue: new Guid("a7def224-0b4a-43e6-874f-5ce4bb770b4a"));

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
    }
}
