using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditRegistration.MsSql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CreditRegistrationSchema");

            migrationBuilder.CreateTable(
                name: "loan_order",
                schema: "CreditRegistrationSchema",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    tariff_id = table.Column<long>(type: "bigint", nullable: false),
                    credit_rating = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_insert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tariff",
                schema: "CreditRegistrationSchema",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    interest_rate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariff", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_loan_order_order_id_user_id",
                schema: "CreditRegistrationSchema",
                table: "loan_order",
                columns: new[] { "order_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_tariff_id",
                schema: "CreditRegistrationSchema",
                table: "tariff",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loan_order",
                schema: "CreditRegistrationSchema");

            migrationBuilder.DropTable(
                name: "tariff",
                schema: "CreditRegistrationSchema");
        }
    }
}
