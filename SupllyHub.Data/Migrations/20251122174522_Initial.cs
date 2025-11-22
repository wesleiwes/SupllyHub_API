using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupllyHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBSUPPLIER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Document = table.Column<string>(type: "varchar(14)", nullable: false),
                    SupplierType = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSUPPLIER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBADDRESS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", nullable: false),
                    Number = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(250)", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBADDRESS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBADDRESS_TBSUPPLIER_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TBSUPPLIER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBPRODUCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPRODUCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPRODUCT_TBSUPPLIER_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TBSUPPLIER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBADDRESS_SupplierId",
                table: "TBADDRESS",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBPRODUCT_SupplierId",
                table: "TBPRODUCT",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBADDRESS");

            migrationBuilder.DropTable(
                name: "TBPRODUCT");

            migrationBuilder.DropTable(
                name: "TBSUPPLIER");
        }
    }
}
