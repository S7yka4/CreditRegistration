using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CreditRegistration.Postgre.Migrations
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    tariff_id = table.Column<long>(type: "bigint", nullable: false),
                    credit_rating = table.Column<double>(type: "double precision", nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    time_insert = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    time_update = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    interest_rate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
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
