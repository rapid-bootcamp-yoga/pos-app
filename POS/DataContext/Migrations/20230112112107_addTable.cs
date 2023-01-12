using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Repository.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fax = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_of_courtesy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hire_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    home_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reports_to = table.Column<int>(type: "int", nullable: false),
                    photo_path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_shipper",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_shipper", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    home_phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    employees_id = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    required_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ship_via = table.Column<int>(type: "int", nullable: false),
                    freight = table.Column<int>(type: "int", nullable: false),
                    ship_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_orders_tbl_customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "tbl_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_orders_tbl_employees_employees_id",
                        column: x => x.employees_id,
                        principalTable: "tbl_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    quantity_per_unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit_price = table.Column<double>(type: "float", nullable: false),
                    units_in_stock = table.Column<int>(type: "int", nullable: false),
                    units_in_order = table.Column<int>(type: "int", nullable: false),
                    reoder_level = table.Column<int>(type: "int", nullable: false),
                    discontinued = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_product_tbl_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "tbl_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_product_tbl_supplier_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "tbl_supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_details_tbl_orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "tbl_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_details_tbl_product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "tbl_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_details_OrdersId",
                table: "order_details",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_ProductsId",
                table: "order_details",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_orders_CustomersId",
                table: "tbl_orders",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_orders_employees_id",
                table: "tbl_orders",
                column: "employees_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_CategoriesId",
                table: "tbl_product",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_SuppliersId",
                table: "tbl_product",
                column: "SuppliersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "tbl_shipper");

            migrationBuilder.DropTable(
                name: "tbl_orders");

            migrationBuilder.DropTable(
                name: "tbl_product");

            migrationBuilder.DropTable(
                name: "tbl_customers");

            migrationBuilder.DropTable(
                name: "tbl_employees");

            migrationBuilder.DropTable(
                name: "tbl_category");

            migrationBuilder.DropTable(
                name: "tbl_supplier");
        }
    }
}
