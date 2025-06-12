using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ACCOUNT_TYPE",
                columns: table => new
                {
                    ACT_CODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ACT_DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ACCOUNT_TYPE", x => x.ACT_CODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_DOCUMENT_TYPE",
                columns: table => new
                {
                    DCT_CODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DCT_DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_DOCUMENT_TYPE", x => x.DCT_CODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_KEY_PROCESS",
                columns: table => new
                {
                    KPR_CODE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    KPR_DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_KEY_PROCESS", x => x.KPR_CODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_KEY_STATE",
                columns: table => new
                {
                    KST_CODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    KST_DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_KEY_STATE", x => x.KST_CODE);
                });

            migrationBuilder.CreateTable(
                name: "TBL_KEY_CUSTOMER",
                columns: table => new
                {
                    KCM_GGID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KCM_DATE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    KCM_HOUR = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    KCM_SEQUENCE = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    KCM_CHANNEL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KCM_PROCESS_KEY_CUSTOMER = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    KCM_KEY_STATE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    KCM_TYPE_KEY_CUSTOMER = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    KCM_VALUE_KEY_CUSTOMER = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    KCM_SOURCE_ENTITY = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KCM_SOURCE_ACCOUNT_NUMBER = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    KCM_SOURCE_ACCOUNT_TYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    KCM_SOURCE_TYPE_ACCOUNT_DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KCM_SOURCE_IDENTIFICATION = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KCM_SOURCE_TYPE_IDENTIFICATION = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    KCM_FIRST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KCM_SECOND_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KCM_SUR_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KCM_SECOND_SUR_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KCM_USER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_KEY_CUSTOMER", x => x.KCM_GGID);
                    table.ForeignKey(
                        name: "FK_TBL_KEY_CUSTOMER_TBL_ACCOUNT_TYPE_KCM_SOURCE_ACCOUNT_TYPE",
                        column: x => x.KCM_SOURCE_ACCOUNT_TYPE,
                        principalTable: "TBL_ACCOUNT_TYPE",
                        principalColumn: "ACT_CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_KEY_CUSTOMER_TBL_DOCUMENT_TYPE_KCM_SOURCE_TYPE_IDENTIFICATION",
                        column: x => x.KCM_SOURCE_TYPE_IDENTIFICATION,
                        principalTable: "TBL_DOCUMENT_TYPE",
                        principalColumn: "DCT_CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_KEY_CUSTOMER_TBL_KEY_PROCESS_KCM_PROCESS_KEY_CUSTOMER",
                        column: x => x.KCM_PROCESS_KEY_CUSTOMER,
                        principalTable: "TBL_KEY_PROCESS",
                        principalColumn: "KPR_CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_KEY_CUSTOMER_TBL_KEY_STATE_KCM_KEY_STATE",
                        column: x => x.KCM_KEY_STATE,
                        principalTable: "TBL_KEY_STATE",
                        principalColumn: "KST_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_KEY_STATE",
                table: "TBL_KEY_CUSTOMER",
                column: "KCM_KEY_STATE");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_PROCESS_KEY_CUSTOMER",
                table: "TBL_KEY_CUSTOMER",
                column: "KCM_PROCESS_KEY_CUSTOMER");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_SEQUENCE",
                table: "TBL_KEY_CUSTOMER",
                column: "KCM_SEQUENCE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_SOURCE_ACCOUNT_TYPE",
                table: "TBL_KEY_CUSTOMER",
                column: "KCM_SOURCE_ACCOUNT_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_SOURCE_IDENTIFICATION",
                table: "TBL_KEY_CUSTOMER",
                column: "KCM_SOURCE_IDENTIFICATION");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_SOURCE_IDENTIFICATION_KCM_VALUE_KEY_CUSTOMER",
                table: "TBL_KEY_CUSTOMER",
                columns: new[] { "KCM_SOURCE_IDENTIFICATION", "KCM_VALUE_KEY_CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_SOURCE_TYPE_IDENTIFICATION",
                table: "TBL_KEY_CUSTOMER",
                column: "KCM_SOURCE_TYPE_IDENTIFICATION");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_KEY_CUSTOMER_KCM_VALUE_KEY_CUSTOMER",
                table: "TBL_KEY_CUSTOMER",
                column: "KCM_VALUE_KEY_CUSTOMER",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_KEY_CUSTOMER");

            migrationBuilder.DropTable(
                name: "TBL_ACCOUNT_TYPE");

            migrationBuilder.DropTable(
                name: "TBL_DOCUMENT_TYPE");

            migrationBuilder.DropTable(
                name: "TBL_KEY_PROCESS");

            migrationBuilder.DropTable(
                name: "TBL_KEY_STATE");
        }
    }
}
