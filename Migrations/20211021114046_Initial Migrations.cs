using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PaymentAPI.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentDetailItems",
                columns: table => new
                {
                    paymentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cardOwnerName = table.Column<string>(type: "text", nullable: true),
                    cardNumber = table.Column<string>(type: "text", nullable: true),
                    expirationDate = table.Column<string>(type: "text", nullable: true),
                    securityCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetailItems", x => x.paymentDetailId);
                });
                migrationBuilder.Sql("INSERT INTO `paymentdetailitems`(`cardOwnerName`, `cardNumber`, `expirationDate`, `securityCode`) VALUES ('Uncle Roger','GN003','03/11/2021','1234567'),"+
                "('Uncle James', 'GN032', '20/11/2021', '808023'),"+
                "('Sister Bety', 'GN025', '29/11/2021', '707035'),"+
                "('Mr Jones', 'GN013', '10/11/2021', '552255');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetailItems");
        }
    }
}
