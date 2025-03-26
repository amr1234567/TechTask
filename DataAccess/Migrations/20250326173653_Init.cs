using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ServiceProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServiceProviders",
                columns: new[] { "Id", "ContactDetails", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { "2364468a-f4da-415f-b170-1e51f3c3bbfc", "Contact Details 3", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Service Provider 3", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "7ed42c39-2f22-4229-b7a2-5c3ca53fa164", "Contact Details 2", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Service Provider 2", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "c710f447-9288-4d60-a7ad-7ee3b11a8219", "Contact Details 1", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Service Provider 1", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Name", "Price", "ServiceProviderId", "UpdatedAt" },
                values: new object[,]
                {
                    { "49a5ac1b-729f-45df-b7b4-df159cb2aed1", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 3", 170.0, "c710f447-9288-4d60-a7ad-7ee3b11a8219", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "4f2ed00c-34ed-4401-b204-2dc175725ade", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 7", 100.0, "2364468a-f4da-415f-b170-1e51f3c3bbfc", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "6b2e8e31-4ec3-4e38-b2f9-4e1a7618bc06", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 1", 100.0, "c710f447-9288-4d60-a7ad-7ee3b11a8219", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "7bf5fb24-786d-46b1-8dd1-316ccab56a24", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 9", 100.0, "2364468a-f4da-415f-b170-1e51f3c3bbfc", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "d20cb994-1b19-44a2-8480-914e7d914e52", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 5", 100.0, "7ed42c39-2f22-4229-b7a2-5c3ca53fa164", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "e4f394cc-4986-4548-9d88-2bc7c5c5ba8d", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 6", 100.0, "7ed42c39-2f22-4229-b7a2-5c3ca53fa164", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "f408f0f2-8c31-4a2a-a309-1c44aaf6ab71", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 8", 100.0, "2364468a-f4da-415f-b170-1e51f3c3bbfc", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "fb442d4b-1a9d-431e-af2d-245913adca77", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 2", 150.0, "c710f447-9288-4d60-a7ad-7ee3b11a8219", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) },
                    { "fd67dbc7-3b02-4712-a458-ed7c871ada79", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local), "Product 4", 100.0, "7ed42c39-2f22-4229-b7a2-5c3ca53fa164", new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ServiceProviderId",
                table: "Products",
                column: "ServiceProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ServiceProviders");
        }
    }
}
