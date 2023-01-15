﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.Repository;

#nullable disable

namespace POS.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("POS.Repository.CategoriesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("picture");

                    b.HasKey("Id");

                    b.ToTable("tbl_category");
                });

            modelBuilder.Entity("POS.Repository.CustomersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("company_name");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fax");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("region");

                    b.HasKey("Id");

                    b.ToTable("tbl_customers");
                });

            modelBuilder.Entity("POS.Repository.EmployeesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("extension");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hire_date");

                    b.Property<string>("HomePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("home_phone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("notes");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("photo");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("photo_path");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("region");

                    b.Property<int>("ReportsTo")
                        .HasColumnType("int")
                        .HasColumnName("reports_to");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<string>("TitleOfCourtesy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title_of_courtesy");

                    b.HasKey("Id");

                    b.ToTable("tbl_employees");
                });

            modelBuilder.Entity("POS.Repository.OrderDetailsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Discount")
                        .HasColumnType("int")
                        .HasColumnName("discount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("unit_price");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.HasIndex("ProductsId");

                    b.ToTable("order_details");
                });

            modelBuilder.Entity("POS.Repository.OrdersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int")
                        .HasColumnName("employees_id");

                    b.Property<int>("Freight")
                        .HasColumnType("int")
                        .HasColumnName("freight");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_name");

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_city");

                    b.Property<string>("ShipCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_country");

                    b.Property<string>("ShipPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_postal_code");

                    b.Property<string>("ShipRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_region");

                    b.Property<int>("ShipVia")
                        .HasColumnType("int")
                        .HasColumnName("ship_via");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("required_date");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("tbl_orders");
                });

            modelBuilder.Entity("POS.Repository.ProductsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("Discontinued")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("discontinued");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("product_name");

                    b.Property<string>("Quantity_per_unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("quantity_per_unit");

                    b.Property<int>("ReorderLevel")
                        .HasColumnType("int")
                        .HasColumnName("reoder_level");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("supplier_id");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("unit_price");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int")
                        .HasColumnName("units_in_stock");

                    b.Property<int>("UnitsOnOrder")
                        .HasColumnType("int")
                        .HasColumnName("units_in_order");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("tbl_product");
                });

            modelBuilder.Entity("POS.Repository.ShippersEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("company_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("tbl_shipper");
                });

            modelBuilder.Entity("POS.Repository.SuppliersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("company_name");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fax");

                    b.Property<string>("HomePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("home_phone");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("region");

                    b.HasKey("Id");

                    b.ToTable("tbl_supplier");
                });

            modelBuilder.Entity("POS.Repository.OrderDetailsEntity", b =>
                {
                    b.HasOne("POS.Repository.OrdersEntity", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.ProductsEntity", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("POS.Repository.OrdersEntity", b =>
                {
                    b.HasOne("POS.Repository.CustomersEntity", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.EmployeesEntity", "Employees")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("POS.Repository.ProductsEntity", b =>
                {
                    b.HasOne("POS.Repository.CategoriesEntity", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.SuppliersEntity", "Suppliers")
                        .WithMany("Products")
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("POS.Repository.CategoriesEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("POS.Repository.CustomersEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("POS.Repository.EmployeesEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("POS.Repository.OrdersEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("POS.Repository.ProductsEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("POS.Repository.SuppliersEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
